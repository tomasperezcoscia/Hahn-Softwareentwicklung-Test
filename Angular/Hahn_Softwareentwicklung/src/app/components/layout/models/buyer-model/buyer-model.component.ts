import { Component, OnInit, Inject } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Buyer } from 'src/app/interfaces/buyer';
import { BuyerService } from 'src/app/services/buyer.service';
import { UtilityService } from 'src/app/Reutilizable/utility.service';

@Component({
  selector: 'app-buyer',
  templateUrl: './buyer-model.component.html',
  styleUrls: ['./buyer-model.component.scss']
})
export class BuyerModelComponent implements OnInit{

  buyerForm: FormGroup;
  actionTitle: string = 'Add';
  actionButton: string = 'Save';

  constructor(
    private aModel: MatDialogRef<BuyerModelComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Buyer,
    private _formBuilder: FormBuilder,
    private _buyerService: BuyerService,
    private _utilityService: UtilityService
  ) {
    this.buyerForm = this._formBuilder.group({
      buyerId: ["903e7232-de9d-4993-93f4-2b0a2816e2f1"],
      buyerFirstName: ['', [Validators.required, Validators.minLength(3)]],
      buyerLastName: ['', [Validators.required, Validators.minLength(3)]],
      buyerEmail: ['', [Validators.email, Validators.minLength(10)]],
      buyerPhone: ['', [Validators.required, Validators.minLength(6)]],
      buyerDateOfBirth: ['', [Validators.required, Validators.minLength(10)]],
      buyerBudget: ['', [Validators.required, Validators.minLength(3)]],
    });

    if (this.data != null) {
      this.actionTitle = 'Edit';
      this.actionButton = 'Update';
    }
  }

  ngOnInit() {
    if (this.data != null) {
      this.buyerForm.patchValue({
        buyerId: this.data.id,
        buyerFirstName: this.data.firstName,
        buyerLastName: this.data.lastName,
        buyerEmail: this.data.email,
        buyerPhone: this.data.phoneNumber,
        buyerDateOfBirth: this.data.dateOfBirth,
        buyerBudget: this.data.budget,
      });
    }
  }

  saveOrUpdate() {
    const buyer: Buyer = {
      id: this.buyerForm.get('buyerId')?.value,
      firstName: this.buyerForm.get('buyerFirstName')?.value,
      lastName: this.buyerForm.get('buyerLastName')?.value,
      email: this.buyerForm.get('buyerEmail')?.value,
      phoneNumber: this.buyerForm.get('buyerPhone')?.value,
      dateOfBirth: this.buyerForm.get('buyerDateOfBirth')?.value,
      budget: this.buyerForm.get('workerBudget')?.value
    }

    if (this.buyerForm.valid) {
      if (this.data == null) {
        this._buyerService.addBuyer(buyer).subscribe({
          next: (data) => {
            console.log(data);
            this._utilityService.showSnackBar('Buyer added successfully', 'close', 'success-snackbar');
            this.aModel.close("true");
          },
          error: (error) => {
            console.log(error);
            this._utilityService.showSnackBar('Error adding buyer', 'close', 'error-snackbar');
          }
        })
      }
      else {
        this._buyerService.updateBuyer(buyer.id,buyer).subscribe({
          next: (data) => {
            console.log(data);
            this._utilityService.showSnackBar('Buyer updated successfully', 'close', 'success-snackbar');
            this.aModel.close("true");
          },
          error: (error) => {
            console.log(error);
            this._utilityService.showSnackBar('Error updating buyer', 'close', 'error-snackbar');
          }
        })
      }
    }
    else {
      this._utilityService.showSnackBar('Please fill all the required fields', 'close', 'error-snackbar');
    }
  }

}
