import { OrderItem } from './order-item';

export interface Order {
    id: string,
    buyerId: string,
    orderDate: Date,
    totalAmount: number,
    orderItems: OrderItem[],
    paymentMethod: string,
    status: number
}

export enum OrderStatus {
    Pending = 1,
    Approved = 2,
    Rejected = 3
}