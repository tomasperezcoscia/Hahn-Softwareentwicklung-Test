import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { DashBoardComponent } from './pages/dash-board/dash-board.component';
import { HRComponent } from './pages/hr/hr.component';
import { SalesComponent } from './pages/sales/sales.component';
import { CarsComponent } from './pages/cars/cars.component';
import { BuyersComponent } from './pages/buyers/buyers.component';


const routes: Routes = [{
  path: '',
  component: LayoutComponent,
  children: [
    {path: 'dashboard', component: DashBoardComponent},
    {path: 'hr', component: HRComponent},
    {path: 'sales', component: SalesComponent},
    {path: 'cars', component: CarsComponent},
    {path: 'buyers', component: BuyersComponent},
  ]

}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
