import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { LoginModel } from 'src/core/services/auth/login';
import { TokenService } from 'src/core/services/auth/token.service';
import { AccountService } from 'src/core/services/auth/account.service';
import { CommonConstants, UserRoles, ValidationMessages } from 'src/core/utils/common-constants';
import { UserService } from 'src/core/services/auth/user.service';
import { FormValidationService } from 'src/core/services/validation/validation.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.styl']
})
export class AuthComponent implements OnInit {
  private model: LoginModel = new LoginModel();
  private returnUrl: string = null;

  public loginForm: FormGroup;
  public formErrors: any = {};
  public submitTouched = false;
  
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private tokenService: TokenService,
    private accountService: AccountService,
    private userService: UserService,
    private formValidationService: FormValidationService
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

    this.formValidationService.setFormData(this.loginForm, ValidationMessages.Auth);
    this.loginForm.valueChanges.subscribe(() => this.validateForm());
  }

  private initializeReturnUrl(): void {
    this.returnUrl = this.route.snapshot.queryParams[CommonConstants.returnUrlSnapshot];
  }

  public onSubmit(): void {
    this.submitTouched = true;

    if (this.loginForm.valid) {
      this.setValuesFromFormToModel();
      this.tokenService.removeTokens();
      this.accountService.authenticate(this.model)
        .subscribe(result => {
          if (result) {
            var user = this.userService.getUserFromLocalStorage();

            if (user.UserRole == UserRoles.administrator) {
              this.router.navigate([this.returnUrl || '/admin']);
            }
            else if (user.UserRole == UserRoles.superadmin) {
              this.router.navigate([this.returnUrl || '/superadmin']);
            }
          } else {
            console.log('error');
          }
        });
    } else {
      this.formValidationService.markFormGroupTouched();
      this.validateForm();
    }
  }

  private setValuesFromFormToModel(): void {
    const values = this.loginForm.getRawValue();
    this.model.Email = values.userEmail;
    this.model.Password = values.userPassword;
  }

  private validateForm(): void {
    this.formErrors = this.formValidationService.validateForm();
  }
}
