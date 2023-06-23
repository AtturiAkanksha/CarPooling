import { Injectable } from '@angular/core';
import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { User } from '../models/user';
import { Observable } from 'rxjs';
import { OfferRide } from '../models/offer-ride';
import { BookRideRequest } from '../models/book-ride-request';
import {OfferRideResponseDTO} from '../models/offer-ride-response'
import { BookRide } from '../models/book-ride';
import {environment} from 'src/environments/environment.prod'

@Injectable({
  providedIn: 'root'
})
export class authService {
  user!: User;
  offerRide!: OfferRide;
  token = localStorage.getItem('token');
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }
    headers = new HttpHeaders({
    'Authorization': `Bearer ${this.token}`,
    'Content-Type': 'application/json' 
  }
  );

  public RegisterUser(user: User): Observable<any> {
    const baseServerUrl = `${this.apiUrl}/User/createUser`;
    return this.http.post<User>(baseServerUrl, user);
  }

  public LogInUser(user: User): Observable<any> {
    const baseServerUrl = `${this.apiUrl}/User/login`;
    return this.http.post<User>(baseServerUrl, user)
  }

  public OfferRide(offerRide: OfferRide): Observable<OfferRide> {
    const baseServerUrl = `${this.apiUrl}/OfferRide/offerRide`;
    return this.http.post<OfferRide>(baseServerUrl, offerRide,{headers:this.headers})
  }

  public GetAllOfferedRides(): Observable<OfferRide> {
    const baseServerUrl = `${this.apiUrl}/OfferRide/getAllOfferedRides`;
    return this.http.get<OfferRide>(baseServerUrl,{headers:this.headers});
  }

  public BookRideRequest(bookRideRequest: BookRideRequest): Observable<BookRideRequest> {
    const baseServerUrl = `${this.apiUrl}/OfferRide/getOfferedRides`;
    return this.http.post<BookRideRequest>(baseServerUrl, bookRideRequest,{headers:this.headers})
  }

  public BookRide(bookRide: BookRide): Observable<BookRide> {
    const baseServerUrl = `${this.apiUrl}/BookRide/bookRide`;
    return this.http.post<BookRide>(baseServerUrl, bookRide,{headers:this.headers})
  }
  
  public GetAllBookedRides(): Observable<OfferRideResponseDTO> {
    const baseServerUrl = `${this.apiUrl}/BookRide/getBookedRides`;
    return this.http.get<OfferRideResponseDTO>(baseServerUrl,{headers:this.headers});
  }
}

