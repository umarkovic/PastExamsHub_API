import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignInComponent } from './signin/signin.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { LayoutModule } from '@angular/cdk/layout';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule, MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { ErrorService } from './shared/error.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatSelectModule } from '@angular/material/select';
import { SignOutComponent } from './signout/signout.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ApplicationStateService } from './application-state.service';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBar, MatSnackBarModule, MatSnackBarRef } from '@angular/material/snack-bar';
import { MatPasswordStrengthModule } from '@angular-material-extensions/password-strength';
import { ErrorStateMatcher } from '@angular/material/core';
import { AppErrorStateMatcher } from './app-matcher';
import { environment } from '../environments/environment';
import { ApiModule, Configuration } from 'projects/authority-api-client/src';
import { ServerHttpInterceptor } from './shared/server-http.interceptor';
import { Router } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    SignOutComponent
  ],
  imports: [
    HttpClientModule,
    MatProgressBarModule,
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    FormsModule,
    MatInputModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatCheckboxModule,
    MatIconModule,
    MatCardModule,
    LayoutModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    MatDialogModule,
    MatSnackBarModule,
    MatPasswordStrengthModule.forRoot(),
    ApiModule.forRoot(() => new Configuration({ basePath: environment.authorityUrl, withCredentials: true })),
  ],
  providers: [
    ApplicationStateService,
    MatSnackBar,
    ErrorService,
    { provide: HTTP_INTERCEPTORS,
      useClass: ServerHttpInterceptor,
       multi: true,
       deps: [Router, ErrorService]
    },
    { provide: ErrorStateMatcher, useClass: AppErrorStateMatcher },
    { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' }},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
