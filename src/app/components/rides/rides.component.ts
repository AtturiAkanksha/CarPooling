import { Component, OnInit } from '@angular/core';
import { authService } from 'src/app/auth.service';
import { Router } from '@angular/router';
import { OfferRide } from 'src/app/offerRide';
import { BookRide } from 'src/app/bookRide';

@Component({
  selector: 'app-rides',
  templateUrl: './rides.component.html',
  styleUrls: ['./rides.component.css']
})
export class RidesComponent{
  offeredRides :OfferRide[] =[];
  tmpObjOfferRide :OfferRide[] =[];
  tempObjBookRide:BookRide[]=[];
  bookedRides:BookRide[]=[];
  servicOutputOfferRide;
  serviceOutputBookRide;

  constructor(private authService: authService, private router:Router) {
    this.authService.GetAllOfferedRides().subscribe({next:
      (res) => { this.servicOutputOfferRide = res;
        this.servicOutputOfferRide.forEach(element => {
          this.pushOfferedRides(element);
        console.log(this.tmpObjOfferRide);
      }
        ),
      this.offeredRides =this.tmpObjOfferRide;
    }
  })

  this.authService.GetAllBookedRides().subscribe({next:
    (res) => { this.serviceOutputBookRide = res;
      this.serviceOutputBookRide.forEach(element => {
        this.pushBookedRides(element);
      console.log(this.tempObjBookRide);
    }
      ),
    this.bookedRides =this.tempObjBookRide;
  }
})
}

pushOfferedRides(element) {
  this.tmpObjOfferRide.push(
    {
      userName : element.userName,
      startPoint: element.startPoint,
      endPoint: element.endPoint,
      date: element.date,
      timeSlot:element.timeSlot,
      seats:element.seats,
      price:element.price,
      stops:element.stops
    })
}

pushBookedRides(element){
  this.tempObjBookRide.push(
    {
      userName : element.userName,
      startPoint: element.startPoint,
      endPoint: element.endPoint,
      date: element.date,
      timeSlot:element.timeSlot,
      seats:element.seats,
      price:element.price,
      offerRideId:element.offerRideId
    })
}
}