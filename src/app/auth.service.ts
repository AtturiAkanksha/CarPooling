import { Injectable } from '@angular/core';
import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { User } from './user';
import { Observable } from 'rxjs';
import { OfferRide } from './offerRide';
import { BookRideRequest } from './bookRideRequest';
import {OfferRideResponseDTO} from './offerRideResponseDTO'
import { BookRide } from './bookRide';

@Injectable({
  providedIn: 'root'
})
export class authService {
  user!: User;
  offerRide!: OfferRide;
  token = localStorage.getItem('token');

  constructor(private http: HttpClient) { }
    headers = new HttpHeaders({
    'Authorization': `Bearer ${this.token}`,
    'Content-Type': 'application/json' 
  }
  );

  public RegisterUser(user: User): Observable<any> {
    const baseServerUrl = " https://carpoolapi1.azurewebsites.net/Api/User/createUser";
    return this.http.post<User>(baseServerUrl, user);
  }

  public LogInUser(user: User): Observable<any> {
    const baseServerUrl = "https://carpoolapi1.azurewebsites.net/Api/User/login";
    return this.http.post<User>(baseServerUrl, user)
  }

  public OfferRide(offerRide: OfferRide): Observable<any> {
    const baseServerUrl = "https://carpoolapi1.azurewebsites.net/Api/OfferRide/offerRide";
    return this.http.post<OfferRide>(baseServerUrl, offerRide,{headers:this.headers})
  }

  public GetAllOfferedRides(): Observable<any> {
    const baseServerUrl = "https://carpoolapi1.azurewebsites.net/Api/OfferRide/getAllOfferedRides";
    return this.http.get<OfferRide>(baseServerUrl,{headers:this.headers});
  }

  public BookRideRequest(bookRideRequest: BookRideRequest): Observable<any> {
    const baseServerUrl = "https://carpoolapi1.azurewebsites.net/Api/OfferRide/getOfferedRides";
    return this.http.post<BookRideRequest>(baseServerUrl, bookRideRequest,{headers:this.headers})
  }

  public BookRide(bookRide: BookRide): Observable<any> {
    const baseServerUrl = "https://carpoolapi1.azurewebsites.net/Api/BookRide/bookRide";
    return this.http.post<BookRide>(baseServerUrl, bookRide,{headers:this.headers})
  }
  
  public GetAllBookedRides(): Observable<any> {
    const baseServerUrl = "https://carpoolapi1.azurewebsites.net/Api/BookRide/getBookedRides";
    return this.http.get<OfferRideResponseDTO>(baseServerUrl,{headers:this.headers});
  }
}

