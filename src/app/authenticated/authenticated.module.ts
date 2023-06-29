import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticatedRoutingModule } from './authenticated-routing.module';
import { BookComponent } from './book/book.component';
import { OfferComponent } from './offer/offer.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { RidesComponent } from './rides/rides.component';

@NgModule({
  declarations: [
    BookComponent,
    OfferComponent,
    HeaderComponent,
    HomeComponent,
    RidesComponent
  ],
  imports: [
    CommonModule,
    AuthenticatedRoutingModule
  ],
  exports: [
    BookComponent,
    OfferComponent,
    HeaderComponent,
    HomeComponent,
    RidesComponent
  ]
})
export class AuthenticatedModule { }
