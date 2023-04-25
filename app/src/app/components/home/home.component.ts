import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  image3:any='/assets/images/img3.png/'

  constructor(private router:Router) {
  }

  bookRide(){
    this.router.navigate(['/book'])
  }
  
  offerRide(){
    this.router.navigate(['/offer'])
  }
}
