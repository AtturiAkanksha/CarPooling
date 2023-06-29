import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { User } from './models/user';
import { authService } from './services/auth-service';

@NgModule({
  declarations: [
    User,
    authService
  ],
  imports: [
    CommonModule,
  ],
  exports: [
    User,
    authService
  ]
})
export class SharedModule { }
