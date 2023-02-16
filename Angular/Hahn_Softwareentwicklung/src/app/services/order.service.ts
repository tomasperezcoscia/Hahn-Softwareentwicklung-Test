import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from 'src/environments/environment';
import { ResponseApi } from '../interfaces/response-api';
import { Order } from '../interfaces/order';
import { OrderItem } from '../interfaces/order-item';
import { Payment } from '../interfaces/payment';
import { ShippingAddress } from '../interfaces/shipping-address';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private apiUrl:string = Environment.endpoint + 'orders';

  constructor(private http: HttpClient) { }

  getOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(`${Environment.endpoint}`);
  }

  getOrder(id: string): Observable<Order> {
    return this.http.get<Order>(`${Environment.endpoint}/${id}`);
  }

  addOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(`${Environment.endpoint}`, order);
  }

  updateOrder(id: string, order: Order): Observable<any> {
    return this.http.put(`${Environment.endpoint}/${id}`, order);
  }

  deleteOrder(id: string): Observable<Order> {
    return this.http.delete<Order>(`${Environment.endpoint}/${id}`);
  }

  getOrderItems(): Observable<OrderItem[]> {
    return this.http.get<OrderItem[]>(`${Environment.endpoint}/orderitems`);
  }

  getOrderOrderItems(id: string): Observable<OrderItem[]> {
    return this.http.get<OrderItem[]>(`${Environment.endpoint}/${id}/orderitems`);
  }

  addOrderItem(orderItem: OrderItem): Observable<OrderItem> {
    return this.http.post<OrderItem>(`${Environment.endpoint}/orderitems`, orderItem);
  }

  updateOrderItem(itemId: string, orderItem: OrderItem): Observable<any> {
    return this.http.put(`${Environment.endpoint}/orderitems/${itemId}`, orderItem);
  }

  deleteOrderItem(itemId: string): Observable<OrderItem> {
    return this.http.delete<OrderItem>(`${Environment.endpoint}/orderitems/${itemId}`);
  }

  getPayments(): Observable<Payment[]> {
    return this.http.get<Payment[]>(`${Environment.endpoint}/payments`);
  }

  getOrderPayments(id: string): Observable<Payment[]> {
    return this.http.get<Payment[]>(`${Environment.endpoint}/${id}/payments`);
  }

  addPayment(payment: Payment): Observable<Payment> {
    return this.http.post<Payment>(`${Environment.endpoint}/payments`, payment);
  }

  updatePayment(paymentId: string, payment: Payment): Observable<any> {
    return this.http.put(`${Environment.endpoint}/payments/${paymentId}`, payment);
  }

  deletePayment(paymentId: string): Observable<Payment> {
    return this.http.delete<Payment>(`${Environment.endpoint}/payments/${paymentId}`);
  }

  getShippingAddresses(): Observable<ShippingAddress[]> {
    return this.http.get<ShippingAddress[]>(`${Environment.endpoint}/shippingaddresses`);
  }

  getOrderShippingAddress(id: string): Observable<ShippingAddress> {
    return this.http.get<ShippingAddress>(`${Environment.endpoint}/${id}/shippingaddress`);
  }

  addShippingAddress(shippingAddress: ShippingAddress): Observable<ShippingAddress> {
    return this.http.post<ShippingAddress>(`${Environment.endpoint}/shippingaddresses`, shippingAddress);
  }

  updateShippingAddress(addressId: string, shippingAddress: ShippingAddress): Observable<any> {
    return this.http.put(`${Environment.endpoint}/shippingaddresses/${addressId}`, shippingAddress);
  }

  deleteShippingAddress(addressId: string): Observable<ShippingAddress> {
    return this.http.delete<ShippingAddress>(`${Environment.endpoint}/shippingaddresses/${addressId}`);
  }


}
