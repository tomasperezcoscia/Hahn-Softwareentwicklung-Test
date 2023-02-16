import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { WorkerModelComponent } from '../../models/worker-model/worker-model.component';
import { WorkerService } from 'src/app/services/worker.service';
import { UtilityService } from 'src/app/Reutilizable/utility.service';
import { Worker } from 'src/app/interfaces/worker';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-hr',
  templateUrl: './hr.component.html',
  styleUrls: ['./hr.component.scss']
})

export class HRComponent implements OnInit, AfterViewInit {

  tableColumns: string[] = ['workerId', 'workerFullName', 'workerEmail', 'workerPhone', 'workerRoleId', 'workerSalary', 'actions'];
  initialData: Worker[] = [];
  workerListData: MatTableDataSource<Worker> = new MatTableDataSource<Worker>(this.initialData);
  @ViewChild(MatPaginator) tablePaginator!: MatPaginator;

  constructor(
    private _workerService: WorkerService,
    private _utilityService: UtilityService,
    private _dialog: MatDialog
  ) { }

  getWorkers() {
    this._workerService.getWorkers().subscribe({
      next: (data) => {
        console.log(data)
        this.workerListData.data = data;
      },
      error: (error) => {
        this._utilityService.showSnackBar("No workers found", "Close", "Oops!")
        console.log(error);
      }
    })
  }

  ngOnInit() {
    this.getWorkers();
  }

  ngAfterViewInit() {
    this.workerListData.paginator = this.tablePaginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.workerListData.filter = filterValue.trim().toLowerCase();
  }

  newWorker() {
    this._dialog.open(WorkerModelComponent, {
      disableClose: true
    }).afterClosed().subscribe(result => {
      if (result === "true") {
        console.log("llegue");
        this.getWorkers();
      }
    });
  }

  editWorker(worker: Worker) {
    this._dialog.open(WorkerModelComponent, {
      disableClose: true,
      data: worker
    }).afterClosed().subscribe(result => {
      if (result === "true") {
        this.getWorkers();
      }
    });
  }

  deleteWorker(worker: Worker) {
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
        this._workerService.deleteWorker(worker.id).subscribe({
          next: (data) => {
            console.log(data);
            this._utilityService.showSnackBar("Worker deleted successfully", "Close", "Success!")
            this.getWorkers();
          },
          error: (error) => {
            this._utilityService.showSnackBar("Worker not deleted", "Close", "Oops!")
            console.log(error);
          }
        })
      }
    })
  }
}