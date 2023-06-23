import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  logo: string = 'assets/images/logo.png';
  isHide=true;
  currentUser:User;
  username:string;

  constructor(private router:Router) {
    this.currentUser = JSON.parse(localStorage.getItem('user'))
    this.username = this.currentUser.email.match(/^([^@]*)@/)[1]
  }
  onLogoClick(){
    this.router.navigate(['/home'])
  }
  onProfileClick(){
    this.isHide= !this.isHide;
  }
  onMyridesClick(){
    this.router.navigate(['/rides'])
  }
  onLogoutClick(){
    localStorage.clear();
    this.router.navigate(['/login']);

  }
}
