import { Injectable } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor() { }

  login(username: string, password: string): boolean {
    if (username == 'test' && password == 'test') {
      sessionStorage.setItem('login', 'true');
      return true;
    }
    return false;
  }

  isLoggedIn() {
    return sessionStorage.getItem('login');
  }

}
