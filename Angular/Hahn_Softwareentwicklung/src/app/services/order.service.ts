import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from 'src/environments/environment';
import { ResponseApi } from '../interfaces/response-api';
import { Order } from '../interfaces/order';
import { OrderItem } from '../interfaces/order-item';
import { PaymentMethod } from '../interfaces/paymentmethod';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private apiUrl:string = Environment.endpoint + 'orders';

  constructor(private http: HttpClient) { }

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.apiUrl}`);
  }

  getOrder(id: string): Observable<Order> {
    return this.http.get<Order>(`${this.apiUrl}/${id}`);
  }

  addOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(`${this.apiUrl}`, order);
  }

  updateOrder(id: string, order: Order): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, order);
  }

  deleteOrder(id: string): Observable<Order> {
    return this.http.delete<Order>(`${this.apiUrl}/${id}`);
  }

  getOrdersByDateRange(startDate: Date, endDate: Date): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.apiUrl}/dateRange/${startDate}/${endDate}`);
  }

  getOrdersByPaymentMethod(paymentMethod: string): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.apiUrl}/paymentMethod/${paymentMethod}`);
  }

  getOrderItems(): Observable<OrderItem[]> {
    return this.http.get<OrderItem[]>(`${this.apiUrl}/orderitems`);
  }

  getOrderOrderItems(id: string): Observable<OrderItem[]> {
    return this.http.get<OrderItem[]>(`${this.apiUrl}/${id}/orderitems`);
  }

  addOrderItem(orderItem: OrderItem): Observable<OrderItem> {
    return this.http.post<OrderItem>(`${this.apiUrl}/orderitems`, orderItem);
  }

  updateOrderItem(itemId: string, orderItem: OrderItem): Observable<any> {
    return this.http.put(`${this.apiUrl}/orderitems/${itemId}`, orderItem);
  }

  deleteOrderItem(itemId: string): Observable<OrderItem> {
    return this.http.delete<OrderItem>(`${this.apiUrl}/orderitems/${itemId}`);
  }

  getPaymentMethods(): Observable<PaymentMethod[]> {
    return this.http.get<PaymentMethod[]>(`${this.apiUrl}/paymentMethods`);
  }

}
