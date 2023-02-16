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
    return this.http.get<Buyer[]>(`${Environment.endpoint}`);
  }

  getBuyer(id: string): Observable<Buyer> {
    return this.http.get<Buyer>(`${Environment.endpoint}/${id}`);
  }

  addBuyer(buyer: Buyer): Observable<Buyer> {
    return this.http.post<Buyer>(`${Environment.endpoint}`, buyer);
  }

  updateBuyer(id: string, buyer: Buyer): Observable<any> {
    return this.http.put(`${Environment.endpoint}/${id}`, buyer);
  }

  deleteBuyer(id: string): Observable<Buyer> {
    return this.http.delete<Buyer>(`${Environment.endpoint}/${id}`);
  }

  getBuyerOrders(id: string): Observable<Order> {
    return this.http.get<Order>(`${Environment.endpoint}/${id}/orders`);
  } 
}
