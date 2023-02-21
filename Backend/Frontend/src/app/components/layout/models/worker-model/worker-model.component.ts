import { Component, OnInit, Inject } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Worker } from 'src/app/interfaces/worker';
import { WorkerService } from 'src/app/services/worker.service';
import { UtilityService } from 'src/app/Reutilizable/utility.service';
import { Role } from 'src/app/interfaces/role';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-worker-model',
  templateUrl: './worker-model.component.html',
  styleUrls: ['./worker-model.component.scss']
})
export class WorkerModelComponent implements OnInit {

  workerForm: FormGroup;
  hidePassword: boolean = true;
  actionTitle: string = 'Add';
  actionButton: string = 'Save';
  roleList: Role[] = [];


  constructor(
    private aModel: MatDialogRef<WorkerModelComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Worker,
    private _formBuilder: FormBuilder,
    private _workerService: WorkerService,
    private _utilityService: UtilityService,
    private _menuService: MenuService
  ) {
    this.workerForm = this._formBuilder.group({
      workerId: ["903e7232-de9d-4993-93f4-2b0a2816e2f1"],
      workerFullName: ['', [Validators.required, Validators.minLength(3)]],
      workerEmail: ['', [Validators.required, Validators.email]],
      workerPhone: ['', [Validators.required, Validators.minLength(8)]],
      workerPassword: ['', [Validators.required, Validators.minLength(6)]],
      workerRoleId: ['', [Validators.required, Validators.minLength(1)]],
      workerSalary: ['', [Validators.required, Validators.minLength(1)]],
    });

    if (this.data != null) {
      this.actionTitle = 'Edit';
      this.actionButton = 'Update';
    }

    this._menuService.getRoles().subscribe({
      next: (data) => {
        this.roleList = data;
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

  ngOnInit() {
    if (this.data != null) {
      this.workerForm.patchValue({
        workerId: this.data.id,
        workerFullName: this.data.name,
        workerEmail: this.data.email,
        workerPhone: this.data.phoneNumber,
        workerPassword: this.data.password,
        workerRoleId: this.data.roleId,
        workerSalary: this.data.salary
      });
    }
  }

  saveOrUpdate() {
    const worker: Worker = {
      id: this.workerForm.get('workerId')?.value,
      name: this.workerForm.get('workerFullName')?.value,
      email: this.workerForm.get('workerEmail')?.value,
      phoneNumber: this.workerForm.get('workerPhone')?.value,
      password: this.workerForm.get('workerPassword')?.value,
      roleId: this.workerForm.get('workerRoleId')?.value,
      salary: this.workerForm.get('workerSalary')?.value
    }

    if (this.data == null) {
      this._workerService.addWorker(worker).subscribe({
        next: (data) => {
          console.log(data);
          this.aModel.close("true");
        },
        error: (error) => {
          console.log(error);
        }
      })
    }else{
      this._workerService.updateWorker(worker.id,worker).subscribe({
        next: (data) => {
          console.log(data);
          this.aModel.close("true");
        },
        error: (error) => {
          console.log(error);
        }
      })
    }
    
  }

}

