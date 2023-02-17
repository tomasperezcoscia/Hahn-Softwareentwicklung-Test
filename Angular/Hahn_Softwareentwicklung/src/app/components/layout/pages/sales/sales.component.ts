import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTable, MatTableDataSource } from '@angular/material/table';

import { CarService } from 'src/app/services/car.service';
import { UtilityService } from 'src/app/Reutilizable/utility.service';
import { OrderService } from 'src/app/services/order.service';
import { BuyerService } from 'src/app/services/buyer.service';

import { Car } from 'src/app/interfaces/car';
import { Order } from 'src/app/interfaces/order';
import { OrderItem } from 'src/app/interfaces/order-item';
import { Buyer } from 'src/app/interfaces/buyer';

import Swal from 'sweetalert2';


@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.scss']
})
export class SalesComponent implements OnInit {

  carList: Car[] = [];
  carListFiltered: Car[] = [];

  buyerList: Buyer[] = [];
  buyerListFiltered: Buyer[] = [];

  orderItems: OrderItem[] = [];
  blockRegisterButton: boolean = false;

  selectedCar!: Car;
  selectedBuyer!: Buyer;
  paymentMethod: string = 'Cash';
  totalAmount: number = 0;

  buyerSalesForm: FormGroup;
  carSalesForm: FormGroup;
  tableColumns: string[] = ['carBrand', 'carModel', 'carPrice', 'carQuantity', 'carTotal', 'carActions'];

  orderItemTable: MatTableDataSource<OrderItem> = new MatTableDataSource<OrderItem>(this.orderItems);

  returnFilteredProducts(search: any): Car {
    const searchedCar = typeof search === 'string' ? search.toLocaleLowerCase : search.model.toLocaleLowerCase;
    return this.carList.find((car: Car) => car.model.toLocaleLowerCase().includes(searchedCar))!;
  }

  returnFilteredBuyers(search: any): Buyer {
    const searchedBuyer = typeof search === 'string' ? search.toLocaleLowerCase : search.firstName.toLocaleLowerCase;
    return this.buyerList.find((buyer: Buyer) => buyer.firstName.toLocaleLowerCase().includes(searchedBuyer))!;
  }

  constructor(
    private _formBuilder: FormBuilder,
    private _carService: CarService,
    private _utilityService: UtilityService,
    private _orderService: OrderService,
    private _buyerService: BuyerService

  ) {
    this.carSalesForm = this._formBuilder.group({
      carSearch: ['', [Validators.required, Validators.minLength(3)]],
      carQuantity: ['', [Validators.required, Validators.minLength(1)]]
    });

    this.buyerSalesForm = this._formBuilder.group({
      buyerSearch: ['', [Validators.required, Validators.minLength(3)]]
    });

    this._buyerService.getBuyers().subscribe({
      next: (data) => {
        console.log(data);
        const list = data as Buyer[];
        console.log(list);
        this.buyerList = list;
      },
      error: (error) => {
        console.log(error);
      }
    })



    this._carService.getCars().subscribe({
      next: (data) => {
        console.log(data);
        const list = data as Car[];
        console.log(list);
      },
      error: (error) => {
        console.log(error);
      }
    })


    this.buyerSalesForm.get('buyerSearch')?.valueChanges.subscribe((search) => {
      this.selectedBuyer = this.returnFilteredBuyers(search);
    });

    this.carSalesForm.get('carSearch')?.valueChanges.subscribe((search) => {
      this.selectedCar = this.returnFilteredProducts(search);
    });
  }


  ngOnInit() {
  }

  showCarDetails(car: Car): string {
    return car.brand + ' ' + car.model;
  }

  carForSale(event: any) {
    this.selectedCar = event.option.value;
  }

  addCarToOrder() {
    if (this.carSalesForm.valid) {
      const _price = this.selectedCar.price;
      const _quantity = this.carSalesForm.get('carQuantity')?.value;
      const _total = _price * _quantity;
      this.totalAmount += _total;

      this.orderItems.push({
        id: "903e7232-de9d-4993-93f4-2b0a2816e2f1",
        carId: this.selectedCar.id,
        carDescription: this.selectedCar.brand + ' ' + this.selectedCar.model,
        orderId: "903e7232-de9d-4993-93f4-2b0a2816e2f1",
        quantity: _quantity,
        priceText: String(_price),
        totalText: String(_total)
      })

      this.orderItemTable = new MatTableDataSource<OrderItem>(this.orderItems);
    }

    this.carSalesForm.patchValue({
      carSearch: '',
      carQuantity: ''
      });
  }

  removeCarFromOrder(orderItem: OrderItem) {
    this.orderItems = this.orderItems.filter((item) => item.id !== orderItem.id);
    this.orderItemTable = new MatTableDataSource<OrderItem>(this.orderItems);
  }

  registerOrder() {
    this.blockRegisterButton = true;
    const order: Order = {
      id: "903e7232-de9d-4993-93f4-2b0a2816e2f1",
      buyerId: "903e7232-de9d-4993-93f4-2b0a2816e2f1",
      shippingAddressId: "903e7232-de9d-4993-93f4-2b0a2816e2f1",
      orderDate: (new Date()).toISOString(),
      status: 0
    }

    this._orderService.addOrder(order).subscribe({
      next: (data) => {
        console.log(data);
        this.orderItems = [];
        this.orderItemTable = new MatTableDataSource<OrderItem>(this.orderItems);
        this.totalAmount = 0;
        this.blockRegisterButton = false;

        Swal.fire({
          title: 'Success!',
          text: 'Order registered successfully',
          icon: 'success',
          confirmButtonText: 'Ok'
        });
      },
      error: (error) => {
        console.log(error);
        this.blockRegisterButton = false;
        Swal.fire({
          title: 'Error!',
          text: 'An error has occurred while registering the order',
          icon: 'error',
          confirmButtonText: 'Ok'
        });
      }
    })
  }

}

