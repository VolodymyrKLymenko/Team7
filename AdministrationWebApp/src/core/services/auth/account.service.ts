import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import decode from 'jwt-decode';

import { User } from 'src/core/models/user';

import { TokenService } from './token.service';
import { UserService } from './user.service';
import { ApiRoutes } from 'src/core/utils/api-routes';
import { LoginModel, LoginResultModel } from './login';
import { ResetPasswordModel } from './reset-password';
import { RegistrationModel } from './registration';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  public user: User;

  constructor(
    private http: HttpClient,
    private tokenService: TokenService,
    private userService: UserService
  ) { }

  public authenticate(model: LoginModel): Observable<LoginResultModel> {
    return this.http.post<LoginResultModel>(ApiRoutes.authenticate, model)
      .pipe(map(result => {
        this.updateLoginationData(result);
        return result;
      }));
  }

  public resetPassword(model: ResetPasswordModel): Observable<LoginResultModel> {
    return this.http.post<LoginResultModel>(ApiRoutes.resetPassword, model)
      .pipe(map(result => {
        this.updateLoginationData(result);
        return result;
      }));
  }

  public registerPatient(model: RegistrationModel): Observable<LoginResultModel> {
    return this.http.post<LoginResultModel>(ApiRoutes.registerPatient, model)
      .pipe(map(result => {
        this.updateLoginationData(result);
        return result;
      }));
  }

  public logOut(): void {
    this.user = null;
    this.tokenService.removeTokens();
  }

  private updateLoginationData(loginResult: LoginResultModel): void {
    if (loginResult !== null) {
      const token = loginResult.accessToken;
      this.tokenService.setAccessToken(token);

      const user = {
        UserRole: decode(token).role,
        Id: loginResult.userId,
        UserName: loginResult.userName
      } as User;

      this.user = user;
      this.tokenService.setUserRole(user.UserRole);
      this.userService.setUserInLocalStorage(user);
    }
  }
}
