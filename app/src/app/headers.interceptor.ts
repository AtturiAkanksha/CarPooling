import { Injectable } from '@angular/core';
import { authService } from './auth.service';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class HeadersInterceptor implements HttpInterceptor {

  constructor(private _authService: authService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token= localStorage.getItem('token');
    const req = request.clone({
      setHeaders:{
        Authorisation:`${token}`,
      }
    })
    return next.handle(req);
  }
}
