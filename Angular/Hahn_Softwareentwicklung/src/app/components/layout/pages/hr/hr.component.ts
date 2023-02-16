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

}