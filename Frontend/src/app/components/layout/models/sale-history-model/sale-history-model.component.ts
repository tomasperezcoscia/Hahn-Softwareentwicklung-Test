import { Component, OnInit, Inject} from '@angular/core';

import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Order } from 'src/app/interfaces/order';
import {OrderItem} from 'src/app/interfaces/order-item';


@Component({
  selector: 'app-sale-history-model',
  templateUrl: './sale-history-model.component.html',
  styleUrls: ['./sale-history-model.component.scss']
})
export class SaleHistoryModelComponent implements OnInit {

  registeredDate: Date;
  paymentMethod: string;
  totalAmount: number;
  orderItems: OrderItem[] = [];

  tableColumns: string[] = ['carDescription', 'carQuantity' , 'carTotal'];

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: Order
  ) { 
    console.log(data)
    this.registeredDate = data.orderDate;
    this.totalAmount = data.totalAmount;
    this.paymentMethod = data.paymentMethod;
    this.totalAmount = data.totalAmount;
    this.orderItems = data.orderItems;

  }

  ngOnInit() {
  }

}
