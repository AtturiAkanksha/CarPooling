import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { authService } from 'src/app/auth.service';
import { OfferRide } from 'src/app/offerRide';
import { __values } from 'tslib';

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent {
  buttonStyle:string ='button-default';
  isFormSubmitted:boolean = false;
  toggled:boolean =  false;
  timeSlot:string;
  timeSlotSelected:string;
  isShowDiv = true;
  seats:number;
  
  timeSlotsArray = [
  {timeSlot:"5am-9am"},
  {timeSlot:"9am-12pm"},
  {timeSlot:"12pm-3pm"},
  {timeSlot:"3pm-6pm"},
  {timeSlot:"6pm-9pm"}
];
  noOfSeats = [
  {seats:1},
  {seats:2},
  {seats:3},
  {seats:4},
  {seats:5}];

constructor(private authService: authService, private router:Router) {
}

offerRideForm: FormGroup = new FormGroup({
  startPoint: new FormControl(null ,[Validators.required]),
  endPoint:new FormControl('',[Validators.required]),
  date:new FormControl('',[Validators.required]),
  stop1:new FormControl(''),
  stop2:new FormControl(''),
  stop3:new FormControl(''),
  price:new FormControl('',[Validators.required]),
})
clickTimeSlot(value:string){
  this.toggled = !this.toggled;
  this.timeSlotSelected=value
}

    onNextClick(){
      this.isShowDiv = !this.isShowDiv;
    }

    clickSeats(value:number){
      this.toggled = !this.toggled;
      this.seats = value;
    }

    submitForm(){
      this.isFormSubmitted = true;
    if(this.offerRideForm.status == "VALID"){
    const startPoint:any = this.offerRideForm.get('startPoint')?.value;
    const endPoint:any = this.offerRideForm.get('endPoint')?.value;
    const date:any = this.offerRideForm.get('date')?.value;
    const price:any = this.offerRideForm.get('price')?.value;
    const timeSlot:string = this.timeSlotSelected;
    const seats:number = this.seats;
    const currentUser = JSON.parse(localStorage.getItem('user'))
    const username = currentUser.email.match(/^([^@]*)@/)[1]
    const offerRide:OfferRide = {startpoint:startPoint, endPoint:endPoint,date:date,price:price,timeSlot:timeSlot,seats:seats,userName: username-, };
    this.authService.offerRide(offerRide).subscribe();
    }
  }
}
