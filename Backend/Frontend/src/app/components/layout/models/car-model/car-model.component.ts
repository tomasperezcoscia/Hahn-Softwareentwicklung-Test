import { Component, OnInit, Inject } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { UtilityService } from 'src/app/Reutilizable/utility.service';
import { Car } from 'src/app/interfaces/car';
import { CarService } from 'src/app/services/car.service';


@Component({
  selector: 'app-car-model',
  templateUrl: './car-model.component.html',
  styleUrls: ['./car-model.component.scss']
})
export class CarModelComponent implements OnInit {

  carForm: FormGroup;
  hidePassword: boolean = true;
  actionTitle: string = 'Add';
  actionButton: string = 'Save';

  constructor(
    private aModel: MatDialogRef<CarModelComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Car,
    private _formBuilder: FormBuilder,
    private _carService: CarService,
    private _utilityService: UtilityService) {
    this.carForm = this._formBuilder.group({
      carId: ["903e7232-de9d-4993-93f4-2b0a2816e2f1"],
      carBrand: ['', [Validators.required, Validators.minLength(3)]],
      carModel: ['', [Validators.required, Validators.minLength(3)]],
      carPrice: ['', [Validators.required, Validators.minLength(1)]],
      carYear: ['', [Validators.required, Validators.minLength(1)]],
      carColor: ['', [Validators.required, Validators.minLength(1)]],
    });

    if (this.data != null) {
      this.actionTitle = 'Edit';
      this.actionButton = 'Update';
    }
  }

  ngOnInit() {
    if (this.data != null) {
      this.carForm.patchValue({
        carId: this.data.id,
        carBrand: this.data.brand,
        carModel: this.data.model,
        carPrice: this.data.price,
        carYear: this.data.year,
        carColor: this.data.color
      });
    }
  }

  saveOrUpdate() {
    const car: Car = {
      id: this.carForm.get('carId')?.value,
      brand: this.carForm.get('carBrand')?.value,
      model: this.carForm.get('carModel')?.value,
      year: this.carForm.get('carYear')?.value,
      price: this.carForm.get('carPrice')?.value,
      color: this.carForm.get('carColor')?.value
    }

    if (this.carForm.valid) {
      if (this.data == null) {
        this._carService.addCar(car).subscribe({
          next: (data) => {
            console.log(data);
            this.aModel.close(true);
          },
          error: (error) => {
            console.log(error);
          }
        })
      } else {
        this._carService.updateCar(car.id,car).subscribe({
          next: (data) => {
            console.log(data);
            this.aModel.close(true);
          },
          error: (error) => {
            console.log(error);
          }
        })
      }
    }
  }


}
