import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ComponentBase } from '../shared/models/componentBase';
import { ApplicationStateService } from '../application-state.service';
import { AuthenticationService, SignOutCommand } from 'projects/authority-api-client/src';

@Component({
  selector: 'app-signout',
  templateUrl: './signout.component.html',
  styleUrls: ['./signout.component.scss']
})
export class SignOutComponent extends ComponentBase implements OnInit {

  logoutId: any;
  diameter = 70;

  constructor(
    private route: ActivatedRoute,
    private applicationStateService: ApplicationStateService,
    private authenticationService: AuthenticationService,
  ) { super(); }

  ngOnInit(): void {

    const isMobile = this.applicationStateService.getIsMobileResolution();

    if (isMobile){
      this.diameter = 70;
    }

    this.logoutId = this.route.snapshot.queryParamMap.get('logoutId');

    const signOutCommand: SignOutCommand = {
      logoutId: this.logoutId
    }

    this.authenticationService
      .authenticationSignOutPost(signOutCommand, 'response')
      .subscribe((response: any) => {
        debugger;
        window.location.href = response.body?.postLogoutRedirectUri as any;
      });

  }

}
