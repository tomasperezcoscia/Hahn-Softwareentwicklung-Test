import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  constructor(private fb: FormBuilder, private _snackBar: MatSnackBar) {
    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
   }

  ngOnInit() {
  }

  login() {
    const user = this.form.value;

    if(user.username === 'admin' && user.password === 'admin'){
      console.log('Login successful');
      // Navigate to dashboard
    }else{
      console.log('Login failed');
      this.error("Username or password is incorrect, please try again");
    }
  }

  error(message: string){
    this._snackBar.open(message, 'Close', {
      duration: 2000,
    });
  }
}
