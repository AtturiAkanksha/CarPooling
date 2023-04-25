import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-offer',
  templateUrl: './offer.component.html',
  styleUrls: ['./offer.component.css']
})
export class OfferComponent {

    offerRideForm = new FormGroup({
    startPoint: new FormControl('',[Validators.required]),
    endPoint:new FormControl('',[Validators.required]),
    time:new FormControl('',[Validators.required]),
    price:new FormControl('',[Validators.required]),
  })
  OfferRide(){
    const emailInput:any = this.offerRideForm.get('email')?.value;
    const passwordInput:any = this.offerRideForm.get('password')?.value;
    const user:User = {email:emailInput, password:passwordInput};
    this.authService.logInUser(user).subscribe((res) => {
      if(res.status == 200){
       this.router.navigate(['/home'])}
    else{
      this.toggleDiv = true}
  });
  
  }
}
