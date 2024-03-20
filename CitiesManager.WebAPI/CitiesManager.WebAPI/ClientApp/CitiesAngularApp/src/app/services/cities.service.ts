import { Injectable } from '@angular/core';
import { City } from '../models/city';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class CitiesService {
  API_BASE_URL = 'https://localhost:7101/';

  constructor(private httpClient: HttpClient) {}

  public getCities(): Observable<City[]> {
    let header = new HttpHeaders();

    header = header.append('Authorization', 'Bearer myToken');

    return this.httpClient.get<City[]>(`${this.API_BASE_URL}api/v1/Cities`, {
      headers: header,
    });
  }

  public postCity(city: City): Observable<City> {
    let header = new HttpHeaders();

    header = header.append('Authorization', 'Bearer myToken');

    return this.httpClient.post<City>(
      `${this.API_BASE_URL}api/v1/Cities`,
      city,
      {
        headers: header,
      }
    );
  }

  public putCity(city: City): Observable<string> {
    let header = new HttpHeaders();

    header = header.append('Authorization', 'Bearer myToken');

    return this.httpClient.put<string>(
      `${this.API_BASE_URL}api/v1/Cities/${city.cityID}`,
      city,
      {
        headers: header,
      }
    );
  }
}
