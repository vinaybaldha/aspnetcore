import { Component, OnInit } from '@angular/core';
import { CitiesService } from '../services/cities.service';
import { City } from '../models/city';
import { CommonModule } from '@angular/common';
import {
  FormArray,
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

  putCityForm: FormGroup;

  editedCityID: string | null = null;

  constructor(private citiesService: CitiesService) {
    this.postCityForm = new FormGroup({
      cityName: new FormControl(null, [Validators.required]),
    });

    this.putCityForm = new FormGroup({
      cities: new FormArray([]),
    });
  }

  loadCities() {
    this.citiesService.getCities().subscribe({
      next: (response: City[]) => {
        this.cities = response;
        this.cities.forEach((city) => {
          this.putCityFromArray.push(
            new FormGroup({
              cityID: new FormControl(city.cityID, [Validators.required]),
              cityName: new FormControl(city.cityName, [Validators.required]),
            })
          );
        });
      },
      error: (error) => {
        console.log(error);
      },
    });
    //  console.log(this.putCityForm);
  }

  ngOnInit(): void {
    this.loadCities();
  }

  get postCity_cityNameControl(): any {
    return this.postCityForm.controls['cityName'];
  }

  get putCityFromArray(): FormArray {
    return this.putCityForm.get('cities') as FormArray;
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

  editClicked(city: City): void {
    this.editedCityID = city.cityID;
  }

  updateClicked(i: number): void {
    this.citiesService
      .putCity(this.putCityFromArray.controls[i].value as City)
      .subscribe({
        next: (response) => {
          console.log(response);
          this.editedCityID = null;
          this.postCityForm.controls[i].reset(this.postCityForm.controls[i]);
        },
        error: (error) => {
          console.log(error);
        },
      });
  }
}
