import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { RouterModule } from '@angular/router';
import { OktaAuthGuard } from '@okta/okta-angular';

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: HomeComponent, canActivate: [OktaAuthGuard] }
    ])
  ]
})
export class CoreModule { }
