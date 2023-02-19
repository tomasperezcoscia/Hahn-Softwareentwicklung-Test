import { Component, OnInit } from '@angular/core';
import { v4 as uuidv4 } from 'uuid';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTable, MatTableDataSource } from '@angular/material/table';

import { CarService } from 'src/app/services/car.service';
import { UtilityService } from 'src/app/Reutilizable/utility.service';
import { OrderService } from 'src/app/services/order.service';
import { BuyerService } from 'src/app/services/buyer.service';

import { Car } from 'src/app/interfaces/car';
import { Order } from 'src/app/interfaces/order';
import { PaymentMethod } from 'src/app/interfaces/paymentmethod';
import { OrderItem } from 'src/app/interfaces/order-item';
import { Buyer } from 'src/app/interfaces/buyer';
import { OrderStatus } from 'src/app/interfaces/order';

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

  paymentMethodsList: PaymentMethod[] = [];
  paymentMethodsListFiltered: PaymentMethod[] = [];

  orderStatusList: OrderStatus[] = [];

  orderItems: OrderItem[] = [];
  blockRegisterButton: boolean = false;

  selectedCar!: Car;
  selectedBuyer!: Buyer;
  selectedOrderStatus!: OrderStatus;
  selectedPaymentMethod!: PaymentMethod;
  defaultPaymentMethod: string = 'Cash';
  
  totalAmount: number = 0;

  buyerSalesForm: FormGroup;
  carSalesForm: FormGroup;
  paymentMethodForm: FormGroup;
  tableColumns: string[] = ['carDescription', 'carQuantity', 'carTotal', 'carActions'];

  orderItemTable: MatTableDataSource<OrderItem> = new MatTableDataSource<OrderItem>(this.orderItems);

  returnFilteredCars(search: any): Car[] {
    const searchedCar = typeof search === 'string' ? search.toLocaleLowerCase().trim() : (search.brand.toLocaleLowerCase() + search.model.toLocaleLowerCase() + String(search.year));
    return this.carList.filter(car => {
      var carName = car.brand.toLocaleLowerCase() + car.model.toLocaleLowerCase() + String(car.year);
      return carName.includes(searchedCar);
    });
  }

  returnFilteredBuyers(search: any): Buyer[] {
    const searchedBuyer = typeof search === 'string' ? search.toLocaleLowerCase().trim() : (search.firstName.toLocaleLowerCase() + search.lastName.toLocaleLowerCase());
    console.log(searchedBuyer);
    return this.buyerList.filter(buyer => {
      var buyerName = buyer.firstName.toLocaleLowerCase() + buyer.lastName.toLocaleLowerCase();
      return buyerName.includes(searchedBuyer);
    });
  }

  returnFilteredPaymentMethods(search: any): PaymentMethod[] {
    const searchedPaymentMethod = typeof search === 'string' ? search.toLocaleLowerCase().trim() : (search.name.toLocaleLowerCase());
    return this.paymentMethodsList.filter(paymentMethod => {
      var paymentMethodName = paymentMethod.name.toLocaleLowerCase();
      return paymentMethodName.includes(searchedPaymentMethod);
    });
  }

  constructor(
    private _formBuilder: FormBuilder,
    private _carService: CarService,
    private _utilityService: UtilityService,
    private _orderService: OrderService,
    private _buyerService: BuyerService

  ) {

    this.paymentMethodForm = this._formBuilder.group({
      paymentMethod: ['', [Validators.required, Validators.minLength(3)]]
    });

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
        this.buyerList = list;
      },
      error: (error) => {
        console.log(error);
      }
    })

    this._orderService.getPaymentMethods().subscribe({
      next: (data) => {
        console.log(data);
        const list = data as PaymentMethod[];
        this.paymentMethodsList = list;
      },
      error: (error) => {
        console.log(error);
      }
    })


    this._carService.getCars().subscribe({
      next: (data) => {
        console.log(data);
        const list = data as Car[];
        this.carList = list;
      },
      error: (error) => {
        console.log(error);
      }
    })


    this.buyerSalesForm.get('buyerSearch')?.valueChanges.subscribe((value) => {
      this.buyerListFiltered = this.returnFilteredBuyers(value);
    });

    this.paymentMethodForm.get('paymentMethod')?.valueChanges.subscribe((value) => {
      this.paymentMethodsListFiltered = this.returnFilteredPaymentMethods(value);
    });

    this.carSalesForm.get('carSearch')?.valueChanges.subscribe((value) => {
      this.carListFiltered = this.returnFilteredCars(value);
    });
  }


  ngOnInit() {
  }

  carForOrder(event: any) {
    this.selectedCar = event.option.value;
  }

  paymentMethodForOrder(event: any) {
    this.selectedPaymentMethod = event.option.value;
  }

  buyerForOrder(event: any) {
    this.selectedBuyer = event.option.value;
  }

  showCarName(car: Car) {
    console.log("Car:" + car.brand + ' ' + car.model + ' ' + car.year)
    if(car.brand != null && car.model != null && car.year != null){
      return car.brand + ' ' + car.model + ' ' + car.year;
    }else{
      return '';
    }
  }

  showBuyerName(buyer: Buyer) {
    console.log("buyer" + buyer.firstName + ' ' + buyer.lastName);
    if(buyer.firstName != null && buyer.lastName != null){
    return buyer.firstName + ' ' + buyer.lastName;
    }else{
      return '';
    }
  }

  showPaymentMethodName(paymentMethod: PaymentMethod) {
    console.log("paymentMethod" + paymentMethod.name);
    return paymentMethod.name;
  }

  addCarToOrder() {
    const carQuantity = this.carSalesForm.get('carQuantity')?.value;
    const carPrice = this.selectedCar.price;
    const _total = carQuantity * carPrice;

    const orderItem: OrderItem = {
      id: uuidv4(),
      carId: this.selectedCar.id,
      carDescription: this.selectedCar.brand + ' ' + this.selectedCar.model + ' ' + this.selectedCar.year,
      quantity: carQuantity,
      priceText: String(carPrice),
      totalText: String(_total)
    }

    console.log(orderItem);


    this.orderItems.push(orderItem);
    this.orderItemTable = new MatTableDataSource<OrderItem>(this.orderItems);
    this.totalAmount += _total;
    this.carSalesForm.patchValue({
      carSearch: '',
      carQuantity: ''
    });
  }

  removeCarFromOrder(orderItem: OrderItem) {
    this.totalAmount -= parseInt(orderItem.totalText);
    this.orderItems = this.orderItems.filter((item) => item.id !== orderItem.id);
    this.orderItemTable = new MatTableDataSource<OrderItem>(this.orderItems);
  }

  addOrder(){
    this.blockRegisterButton = true;
    const order: Order = {
      id: uuidv4(),
      buyerId: this.selectedBuyer.id,
      orderDate: new Date(),
      totalAmount: this.totalAmount,
      orderItems: this.orderItems,
      status: this.selectedOrderStatus
    }

    this._orderService.addOrder(order).subscribe({
      next: (data) => {
        console.log(data);
        this.totalAmount = 0;
        this.orderItems = [];
        this.orderItemTable = new MatTableDataSource<OrderItem>(this.orderItems);

        Swal.fire({
          title: 'Order added successfully!',
          icon: 'success',
          confirmButtonText: 'Ok'
        })
      },
      error: (error) => {
        console.log(error);
      },
      complete: () => {
        this.blockRegisterButton = false;
      }
    })
  }

}

