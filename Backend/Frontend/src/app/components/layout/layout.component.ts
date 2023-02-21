import { Component, OnInit} from '@angular/core';

import { Router } from '@angular/router';
import { Menu } from 'src/app/interfaces/menu';


import { UtilityService } from 'src/app/Reutilizable/utility.service';
import { MenuService } from 'src/app/services/menu.service';


@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit
{

menuList: Menu[] = [];
userEmail: string = '';
userRoleId: number = 0;
userRoleName: string = '';

constructor(
  private router: Router,
  private utilityService: UtilityService,
  private menuService: MenuService
) { }

ngOnInit() {
  const user= this.utilityService.getUserSession();
  console.log(JSON.stringify(user) + "user from layout")

  if(user != null)
  {
    this.userEmail = user.workerEmail;
    this.userRoleId = user.workerRoleId;
    this.userRoleName = user.workerRole;
    this.menuService.getMenuesForRole(String(this.userRoleId)).subscribe({
      next: (data) => {
        this.menuList = data;
      },
      error: (error) => {
        console.log(error);
      }
  });
  }
}

logout(){
  this.utilityService.deleteUserSession();
  this.router.navigate(['/login']);
}



}
