import { AbstractControl, ValidatorFn, ValidationErrors } from '@angular/forms';

// https://github.com/angular/angular/blob/master/packages/forms/src/validators.ts
export class AppValidators {

  // https://stackoverflow.com/questions/51605737/confirm-password-validation-in-angular-6

  static isMatching(matchTo: string): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {

      return !!control.parent &&
        !!control.parent.value &&
        control.value === (control.parent.controls as any)[matchTo].value
        ? null
        : { isMatching: false };
    };
  }
}

/*
static maxLength(maxLength: number): ValidatorFn;

export declare interface ValidatorFn {
    (control: AbstractControl): ValidationErrors | null;
}

export declare type ValidationErrors = {
    [key: string]: any;
};
*/
