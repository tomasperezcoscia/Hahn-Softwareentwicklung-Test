import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';

import { DashBoardComponent } from './pages/dash-board/dash-board.component';
import { HRComponent } from './pages/hr/hr.component';
import { SalesComponent } from './pages/sales/sales.component';
import { CarsComponent } from './pages/cars/cars.component';
import { BuyersComponent } from './pages/buyers/buyers.component';

import { SharedModule } from '../../Reutilizable/shared/shared.module';
import { WorkerModelComponent } from './models/worker-model/worker-model.component'

@NgModule({
  declarations: [
    DashBoardComponent,
    HRComponent,
    SalesComponent,
    CarsComponent,
    BuyersComponent,
    WorkerModelComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,

    SharedModule
  ]
})
export class LayoutModule { }
