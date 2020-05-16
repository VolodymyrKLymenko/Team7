import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';

import { Subscription } from 'rxjs';

import { TokenService } from 'src/core/services/auth/token.service';
import { AccountService } from 'src/core/services/auth/account.service';
import { LoaderService, LoaderState } from 'src/core/services/loader/loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.styl']
})
export class AppComponent {
  public hasLoadedResources = false;
  public screenWidth: number;
  private subscription: Subscription;
  private minWidthForNavDropDown = 768;

  constructor(
    private router: Router,
    private tokenService: TokenService,
    private loaderService: LoaderService,
    private accountService: AccountService
  ) { }

  @HostListener('window:resize', ['$event'])
    onResize(event?) {
      this.initializeScreenWidth();
  }

  public ngOnInit(): void {
    this.setLoaderState();
    this.initializeScreenWidth();
  }

  private initializeScreenWidth(): void {
    this.screenWidth = window.innerWidth;
  }

  private setLoaderState(): void {
    this.subscription = this.loaderService.loaderState
      .subscribe((state: LoaderState) => {
        this.hasLoadedResources = state.show;
      });
  }

  public showNavigationDropDown(): boolean {
    return this.screenWidth <= this.minWidthForNavDropDown;
  }

  public logOutUser(): void {
    /*const revokeModel: RevokeTokenModel = {
      token: this.tokenService.getAccessToken(),
      refreshToken: this.tokenService.getRefreshToken()
    };

    this.accountService.revokeToken(revokeModel)
      .subscribe(result => {
        if (result.Data) {
          this.accountService.logOut();
          this.router.navigate(['/login']);
        } else {
          this.toastNotificationService.showErrorMessage(result.ErrorMessage, result.StatusCode);
        }
      });*/
  }

  public get isAuthenticated(): boolean {
    return this.tokenService.getAccessToken() !== null;
  }
}
