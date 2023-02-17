import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { CarModelComponent } from '../../models/car-model/car-model.component';
import { Car } from 'src/app/interfaces/car';
import { CarService } from 'src/app/services/car.service';
import { UtilityService } from 'src/app/Reutilizable/utility.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.scss']
})
export class CarsComponent implements OnInit, AfterViewInit {

  tableColumns: string[] = ['carId', 'carBrand', 'carModel', 'carPrice', 'actions'];
  initialData: Car[] = [];
  carListData: MatTableDataSource<Car> = new MatTableDataSource<Car>(this.initialData);
  @ViewChild(MatPaginator) tablePaginator!: MatPaginator;

  constructor(
    private _carService: CarService,
    private _utilityService: UtilityService,
    private _dialog: MatDialog
  ) { }

  getCars() {
    this._carService.getCars().subscribe({
      next: (data) => {
        console.log(data)
        this.carListData.data = data;
      },
      error: (error) => {
        this._utilityService.showSnackBar("No cars found", "Close", "Oops!")
        console.log(error);
      }
    })
  }

  ngOnInit() {
    this.getCars();
  }

  ngAfterViewInit() {
    this.carListData.paginator = this.tablePaginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.carListData.filter = filterValue.trim().toLowerCase();
  }

  newCar() {
    this._dialog.open(CarModelComponent, {
      disableClose: true
    }).afterClosed().subscribe((result) => {
      if (result) {
        this.getCars();
      }
    });
  }

  editCar(car: Car) {
    this._dialog.open(CarModelComponent, {
      data: car,
      disableClose: true
    }).afterClosed().subscribe((result) => {
      if (result) {
        this.getCars();
      }
    });
  }

  deleteCar(car: Car) {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
      if (result.isConfirmed) {
        this._carService.deleteCar(car.id).subscribe({
          next: (data) => {
            this._utilityService.showSnackBar("Car deleted", "Close", "Success!")
            this.getCars();
          },
          error: (error) => {
            this._utilityService.showSnackBar("Something went wrong", "Close", "Oops!")
            console.log(error);
          }
        })
      }
    })
  }

}
