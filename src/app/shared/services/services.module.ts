import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { authService } from './auth-service';
import { AuthGuard } from './auth.guard';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeadersInterceptor } from './headers.interceptor';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    authService,
    AuthGuard,
    {provide:HTTP_INTERCEPTORS , useClass:HeadersInterceptor , multi:true}
  ],
})
export class ServicesModule { }
