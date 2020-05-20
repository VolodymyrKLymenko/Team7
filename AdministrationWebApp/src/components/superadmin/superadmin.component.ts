import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { LoginModel } from 'src/core/services/auth/login.model';
import { TokenService } from 'src/core/services/auth/token.service';
import { AccountService } from 'src/core/services/auth/account.service';
import { CommonConstants } from 'src/core/utils/common-constants';

@Component({
  selector: 'app-superadmin',
  templateUrl: './superadmin.component.html',
  styleUrls: ['./superadmin.component.styl']
})
export class SuperAdminComponent implements OnInit {
  public loginForm: FormGroup;
  private model: LoginModel = new LoginModel();
  private returnUrl: string = null;
  
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private tokenService: TokenService,
    private accountService: AccountService
  ) { }

  public ngOnInit(): void {
    this.createForm();
    this.initializeReturnUrl();
  }

  private createForm(): void {
    this.loginForm = new FormGroup({
      userEmail: new FormControl('', [Validators.email, Validators.required]),
      userPassword: new FormControl('', [Validators.required])
    });
  }

  private initializeReturnUrl(): void {
    this.returnUrl = this.route.snapshot.queryParams[CommonConstants.returnUrlSnapshot];
  }

  public onSubmit(): void {
    this.setValuesFromFormToModel();
    this.tokenService.removeTokens();
    this.accountService.authenticate(this.model)
      .subscribe(result => {
        if (result) {
          this.router.navigate([this.returnUrl || '/']);
          // this.notificationService.successAuthentication();
        } else {
          // this.notificationService.showApiErrorMessage(result);
        }
      });
  }

  public navigateToRegistration(): void {
    this.router.navigate(['registration']);
  }

  private setValuesFromFormToModel(): void {
    const values = this.loginForm.getRawValue();
    this.model.Email = values.userEmail;
    this.model.Password = values.userPassword;
  }
}
