import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LogInComponent } from './components/log-in/log-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { HomeComponent } from './components/home/home.component';
import { OfferComponent } from './components/offer/offer.component';
import { BookComponent } from './components/book/book.component';
import { RidesComponent } from './components/rides/rides.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  {path: '', component:SignUpComponent},
  {path: 'login', component:LogInComponent},
  {path: 'home', component:HomeComponent,canActivate :[AuthGuard]},
  {path: 'book', component:BookComponent},
  {path: 'offer', component:OfferComponent},
  {path: 'rides', component:RidesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
