import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user';
import { Observable } from 'rxjs';
import { OfferRide } from './offerRide';

@Injectable({
  providedIn: 'root'
})
export class authService {
 user! :User ;
 ride! :OfferRide;
  constructor(private http: HttpClient) { }

  public registerUser(user: User): Observable<any>{
    const baseServerUrl = " https://localhost:7144/Api/Login/createUser";
    return this.http.post<User>(baseServerUrl ,user);
  }
  
  public logInUser(user: User):Observable<any>{
    const baseServerUrl = "https://localhost:7144/Api/Login/logIn";
    return this.http.post<User>(baseServerUrl,user)
}

  public offerRide(ride: OfferRide):Observable<any>{
    const baseServerUrl = "https://localhost:7144/Api/OfferRide/offerRide";
    return this.http.post<OfferRide>(baseServerUrl,ride)
  }
}

