import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { DashBoardComponent } from './pages/dash-board/dash-board.component';
import { HRComponent } from './pages/hr/hr.component';
import { SalesComponent } from './pages/sales/sales.component';
import { CarsComponent } from './pages/cars/cars.component';
import { BuyersComponent } from './pages/buyers/buyers.component';

import { SharedModule } from '../../Reutilizable/shared/shared.module'

@NgModule({
  declarations: [
    DashBoardComponent,
    HRComponent,
    SalesComponent,
    CarsComponent,
    BuyersComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,

    SharedModule
  ]
})
export class LayoutModule { }
