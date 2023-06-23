import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogInComponent } from './log-in/log-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { UnauthenticatedRoutingModule } from './unauthenticated-routing.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    UnauthenticatedRoutingModule
  ],
  exports: [
    LogInComponent,
    SignUpComponent
  ]
})
export class UnauthenticatedModule { }
