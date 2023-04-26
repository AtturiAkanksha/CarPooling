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
constructor(private authService: authService, private router:Router) {

}
    timeSlot:string; 
    seats:number;
    timeSlots = ["5am-9am", "9am-12pm", "12pm-3pm", "3pm-6pm", "6pm-9pm"];
    noOfSeats = [1,2,3,4,5];

    clickTimeSlot(value:string){
      this.timeSlot = value;
    }

    clickSeats(value:number){
      this.seats = value;
    }

    offerRideForm = new FormGroup({
    startPoint: new FormControl('',[Validators.required]),
    endPoint:new FormControl('',[Validators.required]),
    date:new FormControl('',[Validators.required]),
    stop1:new FormControl('',[Validators.required]),
    stop2:new FormControl('',[Validators.required]),
    stop3:new FormControl('',[Validators.required]),
    price:new FormControl('',[Validators.required]),
  })

  OfferRide(){
    const startPoint:any = this.offerRideForm.get('startPoint')?.value;
    const endPoint:any = this.offerRideForm.get('endPoint')?.value;
    const date:any = this.offerRideForm.get('date')?.value;
    const price:any = this.offerRideForm.get('date')?.value;
    const timeSlot:any = this.timeSlot;
    const seats:number = this.seats;
    const offerRide:OfferRide = {startpoint:startPoint, endPoint:endPoint,date:date,price:price,timeSlot:timeSlot,seats:seats };
    this.authService.offerRide(offerRide).subscribe();
  }
}
