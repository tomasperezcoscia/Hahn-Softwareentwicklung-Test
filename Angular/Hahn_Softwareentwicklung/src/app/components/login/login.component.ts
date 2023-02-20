import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/interfaces/login';
import { WorkerService } from 'src/app/services/worker.service';
import { UtilityService } from 'src/app/Reutilizable/utility.service';
import { Session } from 'src/app/interfaces/session';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  hidePassword: boolean = true;
  showSpinner: boolean = false;

  constructor(private _formBuilder: FormBuilder,
    private _workerService: WorkerService,
    private _utilityService: UtilityService,
    private _router: Router) {
    this.loginForm = this._formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  ngOnInit(): void {
    this.loginForm = this._formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  login() {
    if (this.loginForm.valid) {
      this.showSpinner = true;
      const login: Login = {
        email: this.loginForm.get('email')?.value,
        password: this.loginForm.get('password')?.value
      }
      console.log(`Calling ${this._workerService.apiUrl} with data: `, login);

      this._workerService.login(login).subscribe(
        {
          next: (data) => {
            console.log(data + "data return from loginn");
            // Save the user session and navigate to the dashboard page
            const session: Session = { 
              workerId: data.workerId,
              workerFullName: data.workerFullName,
              workerEmail: data.workerEmail,
              workerRole: data.workerRole,
              workerRoleId: data.workerRoleId,
             };
             console.log("saving session with" + session)
            this._utilityService.saveUserSession(session);
            this._router.navigateByUrl('/pages');
            this.showSpinner = false;
          },
          error: (err) => {
            console.log(err);
            // Show a snack bar with the error message
            const errorMessage = 'An error occurred. Please try again later.';
            this._utilityService.showSnackBar(errorMessage, 'Close', 'error');
            this.showSpinner = false;
          },
        }
      );
    }
  }

}
