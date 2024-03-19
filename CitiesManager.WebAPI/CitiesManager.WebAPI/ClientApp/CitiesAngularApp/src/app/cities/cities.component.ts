import { Component, OnInit } from '@angular/core';
import { CitiesService } from '../services/cities.service';
import { City } from '../models/city';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-cities',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './cities.component.html',
  styleUrl: './cities.component.css',
})
export class CitiesComponent implements OnInit {
  cities: City[] | null = null;

  postCityForm: FormGroup;

  isPostCityFormIsSubmited: boolean = false;

  constructor(private citiesService: CitiesService) {
    this.postCityForm = new FormGroup({
      cityName: new FormControl(null, [Validators.required]),
    });
  }

  loadCities() {
    this.citiesService.getCities().subscribe({
      next: (response: City[]) => {
        this.cities = response;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  ngOnInit(): void {
    this.loadCities();
  }

  get postCity_cityNameControl(): any {
    return this.postCityForm.controls['cityName'];
  }

  postCitySubmited() {
    this.isPostCityFormIsSubmited = true;
    this.citiesService.postCity(this.postCityForm.value).subscribe({
      next: (response) => {
        this.cities?.push(new City(response.cityID, response.cityName));
        this.isPostCityFormIsSubmited = false;
        this.postCityForm.reset();
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
