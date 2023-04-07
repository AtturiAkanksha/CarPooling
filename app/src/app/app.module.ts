
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { HomeComponent } from './components/home/home.component';
import { BookComponent } from './components/book/book.component';
import { RidesComponent } from './components/rides/rides.component';
import { OfferComponent } from './components/offer/offer.component';
import { HeaderComponent } from './components/header/header.component';
import { CarPoolingService } from './car-pooling.service';

@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    LogInComponent,
    HomeComponent,
    BookComponent,
    RidesComponent,
    OfferComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
  ],
  providers: [
    CarPoolingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
