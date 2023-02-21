import { Injectable } from '@angular/core';

import { MatSnackBar } from '@angular/material/snack-bar';
import { Session } from '../interfaces/session';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor(private _snackBar:MatSnackBar) { }

  showSnackBar(message:string,action:string,type:string){
    this._snackBar.open(message,action,{
      duration: 2000,
      horizontalPosition: 'center',
      verticalPosition: 'top',
      panelClass: type
    });
  }

  saveUserSession(session:Session){
    localStorage.setItem('session',JSON.stringify(session));
  }

  getUserSession(){
  const dataString = localStorage.getItem('session');
  const worker = JSON.parse(dataString!);
  return worker;
  }

  deleteUserSession(){
    localStorage.removeItem('session');
  }
}
