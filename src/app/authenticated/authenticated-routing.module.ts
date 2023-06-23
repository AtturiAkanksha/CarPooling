import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/shared/services/auth.guard';
import { BookComponent } from './book/book.component';
import { HomeComponent } from './home/home.component';
import { OfferComponent } from './offer/offer.component';
import { RidesComponent } from './rides/rides.component';

const routes: Routes = [
  {path: 'home', component:HomeComponent,canActivate :[AuthGuard]},
  {path: 'book', component:BookComponent},
  {path: 'offer', component:OfferComponent},
  {path: 'rides', component:RidesComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticatedRoutingModule { }
