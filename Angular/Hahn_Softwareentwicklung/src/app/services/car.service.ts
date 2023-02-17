import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from 'src/environments/environment';
import { Car } from '../interfaces/car';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  private apiUrl:string = Environment.endpoint + 'cars';

  constructor(private http: HttpClient) { }

  getCars(): Observable<Car[]> {
    return this.http.get<Car[]>(`${this.apiUrl}`);
  }

  getCar(id: string): Observable<Car> {
    return this.http.get<Car>(`${this.apiUrl}/${id}`);
  }

  addCar(car: Car): Observable<Car> {
    return this.http.post<Car>(`${this.apiUrl}`, car);
  }

  updateCar(id: string, car: Car): Observable<any> {  
    return this.http.put(`${this.apiUrl}/${id}`, car);
  }

  deleteCar(id: string): Observable<Car> {  
    return this.http.delete<Car>(`${this.apiUrl}/${id}`);
  }
}
