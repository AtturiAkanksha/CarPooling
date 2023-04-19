import { Component } from '@angular/core';
import { authService } from 'src/app/auth.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent {
  logo:any = '/assets/images/logo.png/';
  image1:any = '/assets/images/img1.png/';
  logIn:any='/assets/images/logIn.png/';
  toggleDiv: boolean = false;

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
    this.authService.logInUser(user).subscribe((res) => {
      if(res.status == 200){
       this.router.navigate(['/home'])}
    else{
      this.toggleDiv = true}
  });
  
  } 
  
}
