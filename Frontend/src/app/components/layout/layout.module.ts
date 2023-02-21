import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';

import { HRComponent } from './pages/hr/hr.component';
import { SalesComponent } from './pages/sales/sales.component';
import { CarsComponent } from './pages/cars/cars.component';
import { BuyersComponent } from './pages/buyers/buyers.component';

import { SharedModule } from '../../Reutilizable/shared/shared.module';
import { WorkerModelComponent } from './models/worker-model/worker-model.component';
import { CarModelComponent } from './models/car-model/car-model.component';
import { BuyerModelComponent } from './models/buyer-model/buyer-model.component';
import { SaleHistoryModelComponent } from './models/sale-history-model/sale-history-model.component';
import { SalesHistoryComponent } from './pages/sales-history/sales-history.component';

@NgModule({
  declarations: [
    HRComponent,
    SalesComponent,
    CarsComponent,
    BuyersComponent,
    WorkerModelComponent,
    CarModelComponent,
    BuyerModelComponent,
    SaleHistoryModelComponent,
    SalesHistoryComponent

  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,

    SharedModule
  ]
})
export class LayoutModule { }
