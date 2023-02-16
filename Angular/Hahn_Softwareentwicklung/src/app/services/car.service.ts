import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from 'src/environments/environment';
import { ResponseApi } from '../interfaces/response-api';
import { Car } from '../interfaces/car';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  private apiUrl:string = Environment.endpoint + 'cars';

  constructor(private http: HttpClient) { }

  getCars(): Observable<Car[]> {
    return this.http.get<Car[]>(`${Environment.endpoint}`);
  }

  getCar(id: string): Observable<Car> {
    return this.http.get<Car>(`${Environment.endpoint}/${id}`);
  }

  addCar(car: Car): Observable<Car> {
    return this.http.post<Car>(`${Environment.endpoint}`, car);
  }

  updateCar(id: string, car: Car): Observable<any> {  
    return this.http.put(`${Environment.endpoint}/${id}`, car);
  }

  deleteCar(id: string): Observable<Car> {  
    return this.http.delete<Car>(`${Environment.endpoint}/${id}`);
  }
}
