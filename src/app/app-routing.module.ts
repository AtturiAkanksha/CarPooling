import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: "unauthenticated", loadChildren: () => import('./unauthenticated/unauthenticated.module').then(mod => mod.UnauthenticatedModule) }
  ,
  { path: "authenticated", loadChildren: () => import('./authenticated/authenticated.module').then(mod => mod.AuthenticatedModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
