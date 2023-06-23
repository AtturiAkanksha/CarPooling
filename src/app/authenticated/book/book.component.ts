import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { authService } from 'src/app/shared/services/auth-service';
import { BookRideRequest } from 'src/app/shared/models/book-ride-request';
import { OfferRideResponseDTO } from 'src/app/shared/models/offer-ride-response';
import { BookRide } from 'src/app/shared/models/book-ride';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent {

  timeSlotSelected: string;
  tmpObj: OfferRideResponseDTO[] = [];
  servicOutput;
  clickedCard:OfferRideResponseDTO;
  offeredRides: OfferRideResponseDTO[] = [];
  isFormSubmitted: boolean = false;
  isHidden:boolean = true;

  timeSlotsArray = [
    { timeSlot: "5am-9am" },
    { timeSlot: "9am-12pm" },
    { timeSlot: "12pm-3pm" },
    { timeSlot: "3pm-6pm" },
    { timeSlot: "6pm-9pm" }
  ];

  constructor(private authService: authService, private router: Router) {
  }

  onRadioChange(event: any) {
    this.timeSlotSelected = event.target.id;
  }

  bookRideForm: FormGroup = new FormGroup({
    startPoint: new FormControl(null, [Validators.required]),
    endPoint: new FormControl('', [Validators.required]),
    date: new FormControl('', [Validators.required]),
    timeSlot: new FormControl(''),
  })

  onSubmit() {
    this.isFormSubmitted = true;
    if (this.bookRideForm.status == "VALID") {
      const startPoint: any = this.bookRideForm.get('startPoint')?.value;
      const endPoint: any = this.bookRideForm.get('endPoint')?.value;
      const date: any = this.bookRideForm.get('date')?.value;
      const bookRideRequest: BookRideRequest = { startpoint: startPoint, endPoint: endPoint, date: date, timeSlot: this.timeSlotSelected }
      this.authService.BookRideRequest(bookRideRequest).subscribe(
        (res) => {
          this.servicOutput = res;
          this.servicOutput.forEach(element => {
            this.pushFunc(element);
          }
          ),
            this.offeredRides = this.tmpObj;
            if (this.offeredRides.length ==0 ){
              this.isHidden = false;
            }
        }
      )
    }
  }

  pushFunc(element) {
    this.tmpObj.push(
      {
        userName: element.userName,
        startPoint: element.startPoint,
        endPoint: element.endPoint,
        date: element.date,
        timeSlot: element.timeSlot,
        seats: element.seats,
        price: element.price,
        offerRideId: element.offerRideId
      })
  }

  onCardClick(value:number){
    this.clickedCard = this.offeredRides[value];
    const currentUser = JSON.parse(localStorage.getItem('user'))
    const username = currentUser.email.match(/^([^@]*)@/)[1]
    const bookRide:BookRide = {startPoint:this.clickedCard.startPoint, endPoint:this.clickedCard.endPoint,date:this.clickedCard.date,seats:this.clickedCard.seats,price:this.clickedCard.price,timeSlot:this.clickedCard.timeSlot,offerRideId:this.clickedCard.offerRideId ,userName: username};
    this.authService.BookRide(bookRide).subscribe();
    this.bookRideForm.reset();
  }
}
