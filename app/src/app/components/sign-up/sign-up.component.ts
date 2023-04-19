import { Component } from '@angular/core';
import { authService } from 'src/app/auth.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/user';
import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent {
  logo: any = '/assets/images/logo.png/';
  image1: any = '/assets/images/img1.png/';
  image2: any = '/assets/images/img2.png/';
  toggleDiv: boolean = false;

  constructor(private authService: authService, private router:Router) {
  }
  signUpForm = new FormGroup({
    email :new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
    confirmPassword: new FormControl('', [Validators.required]),
  })
submitForm(){
  const emailInput:any = this.signUpForm.get('email')?.value;
  const passwordInput:any = this.signUpForm.get('password')?.value;
  const confirmPasswordInput:any = this.signUpForm.get('confirmPassword')?.value;
  if(passwordInput == confirmPasswordInput ){
  const user:User = {email:emailInput, password:passwordInput};
  this.authService.registerUser(user).subscribe((res) => {
    if(res.status == 200){
     this.router.navigate(['/login'])}
  else{
    this.toggleDiv = true}
});

}
}
}
