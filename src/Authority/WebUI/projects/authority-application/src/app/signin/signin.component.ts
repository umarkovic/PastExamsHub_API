import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ErrorService } from '../shared/error.service';
import { ComponentBase } from '../shared/models/componentBase';
import { MatDialog } from '@angular/material/dialog';
import { AuthenticationService, SignInCommand } from 'projects/authority-api-client/src';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SignInComponent extends ComponentBase implements OnInit, OnDestroy {
  loginDto: any;
  loginForm!: FormGroup;
  isPasswordHidden = true;
  isValidationShown = false;
  returnUrl: any;

  constructor(
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private router: Router,
    private errorService: ErrorService,
    private authenticationService: AuthenticationService,
  ) { super(); }

  ngOnInit(): void {
    this.isWaiting = false;
    this.returnUrl = this.route.snapshot.queryParamMap.get('ReturnUrl');

    this.errorService.notFoundError.subscribe((problemDetails) => {
      this.isWaiting = false;
      this.errorMessage = problemDetails.detail;
    });

    this.errorService.internalServerError.subscribe((problemDetails) => {
      this.isWaiting = false;
      this.errorMessage = problemDetails.title;
    });

    this.errorService.notReachableError.subscribe((errorMessage) => {
      this.isWaiting = false;
      this.errorMessage = errorMessage;
    });

    this.errorService.validationError.subscribe((validationProblemDetails) => {
      this.isWaiting = false;
      if(!validationProblemDetails?.errors){
        return;
      }
      this.errorMessage = validationProblemDetails?.errors[''].join(",");

      // future task
      // for(const prop of Object.keys(this.loginForm.controls)){
      //   console.log(validationProblemDetails?.errors[prop].join(","));
      // }
    });


    this.loginForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      rememberMe: [''],
      returnUrl: ['']
    });
  }

  ngOnDestroy(): void {
  }


   login(): void {
    this.isValidationShown = true;
    if (this.loginForm.valid) {
      this.isWaiting = true;

      let rememberMe = false;
      if (rememberMe){
        rememberMe = this.loginForm.value.rememberMe;
      }

      const signInCommand: SignInCommand = {
        email: this.loginForm.value.email,
        password: this.loginForm.value.password,
        rememberMe,
        returnUrl: this.returnUrl
      };

      this.authenticationService
      .authenticationSignInPost(signInCommand, 'response')
      .subscribe((response: any) => {
        this.isWaiting = false;
        window.location.href = this.returnUrl;
      });
    }
  }
}
