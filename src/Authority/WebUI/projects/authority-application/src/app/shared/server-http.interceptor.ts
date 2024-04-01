import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent
} from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ErrorService } from './error.service';
import { Router } from '@angular/router';

@Injectable()
export class ServerHttpInterceptor implements HttpInterceptor {
  constructor(private router: Router, private errorService: ErrorService) {}
  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {

    return next.handle(request).pipe(
      catchError((httpError: any) => {
        console.log('Handled', httpError);
        this.errorService.publishError(httpError);
        return throwError(httpError);
      })
    );
  }
}
