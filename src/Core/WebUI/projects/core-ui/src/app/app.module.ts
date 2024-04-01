import { ShellModule } from './shell/shell.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { environment } from '../environments/environment';
import { ErrorService } from './shared/services/error.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ServerHttpInterceptor } from './shared/interceptors/server-http.interceptor';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { AuthRoutingModule } from './auth-routing.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    //BrowserAnimationsModule,
    FlexLayoutModule,
    AuthRoutingModule
  ],
  providers: [
    ErrorService,
    { 
      provide: HTTP_INTERCEPTORS,
      useClass: ServerHttpInterceptor,
      multi: true,
      deps: [Router, ErrorService]
    },
   ],
  bootstrap: [AppComponent]
})
export class AppModule { }
