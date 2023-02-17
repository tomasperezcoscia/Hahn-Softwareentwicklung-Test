import { OrderItem } from './order-item';

export interface Order {
    id: string,
    buyerId: string,
    orderDate: string,
    totalAmount: number,
    orderItems: OrderItem[],
    status: number
}

export enum OrderStatus {
    Pending = 1,
    Approved = 2,
    Rejected = 3
}