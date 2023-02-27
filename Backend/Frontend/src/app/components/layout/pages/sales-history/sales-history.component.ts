import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';


import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { MAT_DATE_FORMATS } from '@angular/material/core';
import * as moment from 'moment';


import { Order } from 'src/app/interfaces/order';
import { OrderItem } from 'src/app/interfaces/order-item';
import { SaleHistoryModelComponent } from '../../models/sale-history-model/sale-history-model.component';

import { UtilityService } from 'src/app/Reutilizable/utility.service';
import { OrderService } from 'src/app/services/order.service';



export const MY_DATA_FORMATS = {
  parse: {
    dateInput: 'DD/MM/YYYY',
  },
  display: {
    dateInput: 'DD/MM/YYYY',
    monthYearLabel: 'MMMM YYYY',
  },
};



@Component({
  selector: 'app-sales-history',
  templateUrl: './sales-history.component.html',
  styleUrls: ['./sales-history.component.scss'],
  providers: [
    { provide: MAT_DATE_FORMATS, useValue: MY_DATA_FORMATS },
  ],
})
export class SalesHistoryComponent implements OnInit, AfterViewInit {

  searchForm: FormGroup;

  searchOptions: any[] = [
    { value: 'orderDate', viewValue: 'Date' },
    { value: 'paymentMethod', viewValue: 'Payment Method' },
  ];

  tableColumns: string[] = ['orderDate', 'paymentMethod', 'totalAmount', 'actions'];
  initialData: Order[] = [];
  dataSource = new MatTableDataSource<Order>(this.initialData);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(public dialog: MatDialog,
    private _formBuilder: FormBuilder,
    private _dialog: MatDialog,
    private _orderService: OrderService,
    private _utilityService: UtilityService) {

    this.searchForm = this._formBuilder.group({
      searchOption: ['orderDate'],
      searchValue: [''],
      dateStart: [''],
      dateEnd: [''],
    });

    this._orderService.getOrders().subscribe((orders: Order[]) => {
      this.initialData = orders;
      this.dataSource.data = this.initialData;
    });

    this.searchForm.get('searchOption')?.valueChanges.subscribe((value: string) => {
      this.searchForm.patchValue({
        searchValue: '',
        dateStart: '',
        dateEnd: '',
      })
    });


  }

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  

  openDialog(order: Order) {
    this.dialog.open(SaleHistoryModelComponent, {
      width: '500px',
      data: order
    });
  }

  applyFilter(event:Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  seeOrderDetails(order: Order) {
    this._orderService.getOrderOrderItems(order.id).subscribe({
      next: (data) => {
        order.orderItems = data;
        this._dialog.open(SaleHistoryModelComponent, {
          width: '700px',
          data: order,
          disableClose: true
        });
      }
    });
  }

  searchOrders() {
    const searchOption = this.searchForm.get('searchOption')?.value;
    const searchValue = this.searchForm.get('searchValue')?.value;
    const dateStart = this.searchForm.get('dateStart')?.value;
    const dateEnd = this.searchForm.get('dateEnd')?.value;

    if (searchOption === 'orderDate') {
      const dateStartFormatted = moment(dateStart).format('YYYY-MM-DD');
      const dateEndFormatted = moment(dateEnd).format('YYYY-MM-DD');

      this._orderService.getOrdersByDateRange(dateStart, dateEnd).subscribe((orders: Order[]) => {
        this.dataSource.data = orders;
      });
    } else if (searchOption === 'paymentMethod') {
      this._orderService.getOrdersByPaymentMethod(searchValue).subscribe((orders: Order[]) => {
        this.dataSource.data = orders;
      });}
  }

}


