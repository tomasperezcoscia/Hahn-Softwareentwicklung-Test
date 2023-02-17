import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from 'src/environments/environment';
import { ResponseApi } from '../interfaces/response-api';
import { Order } from '../interfaces/order';
import { OrderItem } from '../interfaces/order-item';
import { Payment } from '../interfaces/payment';

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

  getPayments(): Observable<Payment[]> {
    return this.http.get<Payment[]>(`${this.apiUrl}/payments`);
  }

  getOrderPayments(id: string): Observable<Payment[]> {
    return this.http.get<Payment[]>(`${this.apiUrl}/${id}/payments`);
  }

  addPayment(payment: Payment): Observable<Payment> {
    return this.http.post<Payment>(`${this.apiUrl}/payments`, payment);
  }

  updatePayment(paymentId: string, payment: Payment): Observable<any> {
    return this.http.put(`${this.apiUrl}/payments/${paymentId}`, payment);
  }

  deletePayment(paymentId: string): Observable<Payment> {
    return this.http.delete<Payment>(`${this.apiUrl}/payments/${paymentId}`);
  }


}
