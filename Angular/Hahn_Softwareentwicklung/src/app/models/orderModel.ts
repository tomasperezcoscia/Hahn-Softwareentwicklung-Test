import { BuyerModel } from './buyerModel';
import { OrderItemModel } from './orderItemModel';
import { PaymentModel } from './paymentModel';
import { ShippingAddressModel } from './shippingAddressModel';

export class OrderModel {
  id: string;
  buyer: BuyerModel;
  orderDate: Date;
  orderItems: OrderItemModel[];
  totalAmount: number;
  payments: PaymentModel[];
  status: OrderStatus;
  shippingAddress: ShippingAddressModel;

    constructor(id: string, buyer: BuyerModel, orderDate: Date, orderItems: OrderItemModel[], totalAmount: number, payments: PaymentModel[], status: OrderStatus, shippingAddress: ShippingAddressModel) {
        this.id = id;
        this.buyer = buyer;
        this.orderDate = orderDate;
        this.orderItems = orderItems;
        this.totalAmount = totalAmount;
        this.payments = payments;
        this.status = status;
        this.shippingAddress = shippingAddress;
    }
}

export enum OrderStatus {
    Pending = 'Pending',
    Processing = 'Processing',
    Shipped = 'Shipped',
    Delivered = 'Delivered',
    Cancelled = 'Cancelled',
  }