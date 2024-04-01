import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './signin/signin.component';
import { SignOutComponent } from './signout/signout.component';


const routes: Routes = [
  { path: 'signin', component: SignInComponent},
  { path: 'signout', component: SignOutComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
