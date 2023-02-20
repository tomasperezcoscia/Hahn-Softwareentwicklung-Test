import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { Buyer } from 'src/app/interfaces/buyer';
import { BuyerService } from 'src/app/services/buyer.service';
import { BuyerModelComponent } from '../../models/buyer-model/buyer-model.component';

import { UtilityService } from 'src/app/Reutilizable/utility.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-buyers',
  templateUrl: './buyers.component.html',
  styleUrls: ['./buyers.component.scss']
})
export class BuyersComponent implements OnInit, AfterViewInit {

  tableColumns: string[] = ['buyerId', 'buyerFirstName', 'buyerLastName', 'buyerEmail', 'buyerPhone', 'buyerDateOfBirth', 'actions'];
  initialData: Buyer[] = [];
  buyerListData: MatTableDataSource<Buyer> = new MatTableDataSource<Buyer>(this.initialData);
  @ViewChild(MatPaginator) tablePaginator!: MatPaginator;

  constructor(
    private _buyerService: BuyerService,
    private _utilityService: UtilityService,
    private _dialog: MatDialog
  ) { }

  getBuyers() {
    this._buyerService.getBuyers().subscribe({
      next: (data) => {
        console.log(data)
        this.buyerListData.data = data;
      },
      error: (error) => {
        this._utilityService.showSnackBar("No buyers found", "Close", "Oops!")
        console.log(error);
      }
    })
  }

  ngOnInit() {
    this.getBuyers();
  }

  ngAfterViewInit() {
    this.buyerListData.paginator = this.tablePaginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.buyerListData.filter = filterValue.trim().toLowerCase();
  }

  newBuyer() {
    this._dialog.open(BuyerModelComponent, {
      disableClose: true
    }).afterClosed().subscribe(result => {
      if (result === "true") {
        this.getBuyers();
      }
    })
  }

  editBuyer(buyer: Buyer) {
    this._dialog.open(BuyerModelComponent, {
      disableClose: true,
      data: buyer
    }).afterClosed().subscribe(result => {
      if (result === "true") {
        this.getBuyers();
      }
    })
  }

  deleteBuyer(buyer: Buyer) {
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
        this._buyerService.deleteBuyer(buyer.id).subscribe({
          next: (data) => {
            this._utilityService.showSnackBar("Buyer deleted successfully", "Close", "Success!")
            this.getBuyers();
          },
          error: (error) => {
            this._utilityService.showSnackBar("Error deleting buyer", "Close", "Oops!")
            console.log(error);
          }
        })
      }
    })
  }

}
