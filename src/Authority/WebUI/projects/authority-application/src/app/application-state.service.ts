import {Injectable} from '@angular/core';

@Injectable()
export class ApplicationStateService {

  private isMobileResolution: boolean;

  constructor() {
    if (window.innerWidth < 700) {
      this.isMobileResolution = true;
    } else {
      this.isMobileResolution = false;
    }
  }

  public getIsMobileResolution(): boolean { 
    return this.isMobileResolution;
  }
}
 