import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class authService {
 user! :User ;
  constructor(private http: HttpClient) { }

  public registerUser(user: User): Observable<any>{
    const baseServerUrl = " https://localhost:7144/Api/CarPooling/createUser";
    return this.http.post<User>(baseServerUrl ,user);
  }
  
  public logInUser(user: User):Observable<any>{
    const baseServerUrl = "https://localhost:7144/Api/CarPooling/logIn";
    return this.http.post<User>(baseServerUrl,user)
}
}
