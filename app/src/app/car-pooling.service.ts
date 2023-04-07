import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CarPoolingService {

  constructor(private http: HttpClient) { }
  baseServerUrl: "http://localhost:59962/"

  registeruser(){
    return this.http.post(this.baseServerUrl + "User", nulll)
  }

}
