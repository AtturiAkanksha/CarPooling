import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  image3: string = 'assets/images/img3.png'
  currentUser: User;
  userName: string;

  constructor(private router: Router) {
    this.currentUser = JSON.parse(localStorage.getItem('user'))
    this.userName = this.currentUser.email.match(/^([^@]*)@/)[1]
  }

  bookRide() {
    this.router.navigate(['/book'])
  }

  offerRide() {
    this.router.navigate(['/offer'])
  }
}
