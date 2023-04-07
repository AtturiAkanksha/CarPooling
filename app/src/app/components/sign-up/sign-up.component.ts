import { Component } from '@angular/core';
import { CarPoolingService } from 'src/app/car-pooling.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent {
  logo:any = '/assets/images/logo.png/';
  image1:any = '/assets/images/img1.png/';
  image2:any='/assets/images/img2.png/'

  constructor(private carPoolingService: CarPoolingService){

  }
  signUpForm : FormGroup = new FormGroup({
    email : new FormControl('',[Validators.required, Validators.pattern("^[a-zA-Z0-9._]+@[a-z]+\\.[a-z]{2,5}$")]),
    password :new FormControl('',[Validators.required, Validators.pattern("^[a-zA-Z0-9._]+@[a-z]+\\.[a-z]{2,5}$")]),
    confirmPassword : new FormControl('',[Validators.required, Validators.pattern("^[a-zA-Z0-9._]+@[a-z]+\\.[a-z]{2,5}$")]),
  })


}
