import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from 'src/environments/environment';
import { Buyer } from '../interfaces/buyer';
import { Order } from '../interfaces/order';

@Injectable({
  providedIn: 'root'
})
export class BuyerService {

  private apiUrl:string = Environment.endpoint + 'buyers';

  constructor(private http: HttpClient) { }

  getBuyers(): Observable<Buyer[]> {
    return this.http.get<Buyer[]>(`${this.apiUrl}`);
  }

  getBuyer(id: string): Observable<Buyer> {
    return this.http.get<Buyer>(`${this.apiUrl}/${id}`);
  }

  addBuyer(buyer: Buyer): Observable<Buyer> {
    return this.http.post<Buyer>(`${this.apiUrl}`, buyer);
  }

  updateBuyer(id: string, buyer: Buyer): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, buyer);
  }

  deleteBuyer(id: string): Observable<Buyer> {
    return this.http.delete<Buyer>(`${this.apiUrl}/${id}`);
  }

  getBuyerOrders(id: string): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.apiUrl}/${id}/orders`);
  } 
}
