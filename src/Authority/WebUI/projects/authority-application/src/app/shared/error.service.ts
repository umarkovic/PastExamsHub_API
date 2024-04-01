import { Observable, of, BehaviorSubject, ReplaySubject } from 'rxjs';
import { Injectable } from '@angular/core';
import { ProblemDetails } from './models/problemDetails';
import { ValidationProblemDetails } from './models/validationProblemDetails';

@Injectable({
    providedIn: 'root',
})
export class ErrorService {

    notFoundError: ReplaySubject<ProblemDetails> = new ReplaySubject(0);

    validationError: ReplaySubject<ValidationProblemDetails> = new ReplaySubject(0);

    internalServerError: ReplaySubject<ProblemDetails> = new ReplaySubject(0);

    notReachableError: ReplaySubject<any> = new ReplaySubject(0);

    constructor() {
    }

    public publishError(httpError: any): void {
        switch(httpError.status)  {
            case 404 : {
                this.notFoundError.next(httpError.error as ProblemDetails);
                break;
                }
            case 400: {
                this.validationError.next(httpError.error as ValidationProblemDetails);
                break;
            }
            case 500: {
                this.internalServerError.next(httpError.error as ProblemDetails);
                break;
            }
            case 0: {
                this.notReachableError.next('Server is not reachable, please try again');
                break;
            }
          }
    }

 }
