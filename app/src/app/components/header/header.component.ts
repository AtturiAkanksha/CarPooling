import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/user';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  logo:any='/assets/images/logo.png/'
  user:any='/assets/images/john.jpg/'
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
  onProfileCilck(){
    this.isHide= !this.isHide;
  }
  onMyridesClick(){
    this.router.navigate(['/rides'])
  }
  onLogoutClick(){
    localStorage.removeItem('user');
    this.router.navigate(['/login'])

  }
}
