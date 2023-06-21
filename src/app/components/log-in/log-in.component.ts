import { Component } from '@angular/core';
import { authService } from 'src/app/auth.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/user';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent {
  logo:string = 'assets/images/logo.png';
  image1:string = 'assets/images/img1.png';
  logIn:string='assets/images/logIn.png';
  validLogin:Boolean =true;
  errormessage: string;
  currentUser:User;

  constructor(private authService: authService, private router:Router) {
  }
  logInForm = new FormGroup({
    email :new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
  })
  onLogIn(){
    const emailInput:any = this.logInForm.get('email')?.value;
    const passwordInput:any = this.logInForm.get('password')?.value;
    const user:User = {email:emailInput, password:passwordInput};
    this.authService.LogInUser(user).subscribe({
     next:(res) => {
      this.validLogin;
      this.router.navigate(['/home'])
      localStorage.setItem('user',JSON.stringify(user));
      localStorage.setItem('login-object',JSON.stringify(res));
      localStorage.setItem('token',(res.token));
      localStorage.setItem('userId',JSON.stringify(res.userId));
     },
     error:(err:HttpErrorResponse) =>{this.errormessage = err.error ;
    this.validLogin = false} 
  });
  }
} 

