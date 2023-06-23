import { Component} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { authService } from 'src/app/shared/services/auth-service';
import { OfferRide } from 'src/app/shared/models/offer-ride';
import { __values } from 'tslib';

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent {
  buttonStyle:string ='button-default';
  isFormSubmitted:boolean = false;
  time:any;
  timeSlotSelected:string ;
  isShowDiv = true;
  seats:number;
  stopsArray:string[] = [];
  stops:string='';
  additionalStop:string ="";
  displayStop = 0;
  
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

onRadioChange(event:any){
   this.timeSlotSelected= event.target.id;
}
    onNextClick(){
      this.isShowDiv = !this.isShowDiv;
    }

    clickSeats(event:any){
      this.seats = event.target.id;
    }

    offerRideForm: FormGroup = new FormGroup({
      startPoint: new FormControl(null ,[Validators.required]),
      endPoint:new FormControl('',[Validators.required]),
      date:new FormControl('',[Validators.required]),
      timeSlot:new FormControl(''),
      seats: new FormControl(''),
      stop : new FormControl(''),
      additionalStop : new FormControl(''),
      price:new FormControl('',[Validators.required]),
    })
    incrementStop() {
      this.displayStop++;
      this.stopsArray.push(this.offerRideForm.get('stop')?.value)
      this.stops = this.stopsArray.join(',')
    }
    
    submitForm(){
      this.isFormSubmitted = true;
    if(this.offerRideForm.status == "VALID"){
    const startPoint:any = this.offerRideForm.get('startPoint')?.value;
    const endPoint:any = this.offerRideForm.get('endPoint')?.value;
    const date:any = this.offerRideForm.get('date')?.value;
    const price:any = this.offerRideForm.get('price')?.value;
    const seats:number = this.seats;
    const stops:string = this.stops;
    const currentUser = JSON.parse(localStorage.getItem('user'))
    const username = currentUser.email.match(/^([^@]*)@/)[1]
    const offerRide:OfferRide = {startPoint:startPoint, endPoint:endPoint,date:date,price:price,timeSlot:this.timeSlotSelected,stops:stops,seats:seats,userName: username};
    this.authService.OfferRide(offerRide).subscribe();
    this.offerRideForm.reset();
    }
  }
}
