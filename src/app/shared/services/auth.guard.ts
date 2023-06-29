import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { authService } from './auth-service';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard {
  user: User = { email: "", password: "" }
  constructor(private auth: authService, private router: Router) {

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (this.auth.LogInUser(this.user)) {
      return true;
    }
    return false;
  }

}
