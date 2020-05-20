import { Component, HostListener, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Subscription } from 'rxjs';

import { TokenService } from 'src/core/services/auth/token.service';
import { AccountService } from 'src/core/services/auth/account.service';
import { LoaderService, LoaderState } from 'src/core/services/loader/loader.service';
import { User } from 'src/core/models/user.model';
import { UserService } from 'src/core/services/auth/user.service';
import { UserRoles } from 'src/core/utils/common-constants';
import { EventModel } from 'src/core/models/event.model';
import { EventService } from 'src/core/services/events/event.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.styl']
})
export class AppComponent implements OnInit {
  public hasLoadedResources = false;
  public screenWidth: number;
  public user: User = null;
  public events: EventModel[]

  private subscription: Subscription;
  private minWidthForNavDropDown = 768;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private tokenService: TokenService,
    private loaderService: LoaderService,
    private accountService: AccountService,
    private eventService: EventService,
    private userService: UserService
  ) { }

  @HostListener('window:resize', ['$event'])
    onResize(event?) {
      this.initializeScreenWidth();
  }

  public ngOnInit(): void {
    this.setLoaderState();
    this.initializeUser();
    this.initializeScreenWidth();
    this.loadEvents();
  }

  private initializeScreenWidth(): void {
    this.screenWidth = window.innerWidth;
  }

  private initializeUser(): void {
    console.log('initi');
    this.user = this.userService.getUserFromLocalStorage();
  }

  private setLoaderState(): void {
    this.subscription = this.loaderService.loaderState
      .subscribe((state: LoaderState) => {
        this.hasLoadedResources = state.show;
      });
  }

  private loadEvents(): void {
    this.eventService.getAll()
      .subscribe(res => {
        console.log(res);
        this.events = res;
      });
  }

  public showNavigationDropDown(): boolean {
    return this.screenWidth <= this.minWidthForNavDropDown;
  }

  public logOutUser(): void {
    this.accountService.logOut();
    this.router.navigate(['/login']);
  }

  public get isAuthenticated(): boolean {
    return this.tokenService.getAccessToken() !== null;
  }

  public navigateAdmin(): void {
    var user = this.userService.getUserFromLocalStorage();

    if (user.UserRole == UserRoles.administrator) {
      this.router.navigate(['/admin']);
    }
    else if (user.UserRole == UserRoles.superadmin) {
      this.router.navigate(['/superadmin']);
    }
  }

  public get isStartPage(): boolean {
    return this.route.snapshot.firstChild == null;
  }
}
