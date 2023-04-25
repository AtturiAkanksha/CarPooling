import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  logo:any='/assets/images/logo.png/'
  user:any='/assets/images/john.jpg/'
  isHide=true;

  constructor(private router:Router) {
    
  }
  onProfileCilck(){
    this.isHide= !this.isHide;
  }
  onMyridesClick(){
    this.router.navigate(['/rides'])
  }
}
