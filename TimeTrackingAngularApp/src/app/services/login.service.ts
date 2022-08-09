import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { API_URL } from '../constants';
import { AuthenticatedResponse } from '../models/AuthenticatedResponse';
import { LoginRequest } from '../models/LoginRequest';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  constructor(private httpClient: HttpClient, private router: Router) {}

  private headers: HttpHeaders = new HttpHeaders({
    'Content-Type': 'application/json',
  });

  loginUser(user: LoginRequest, header: { HttpHeader }) {
    return this.httpClient.post<AuthenticatedResponse>(
      `${API_URL}/token/login`,
      user,
      { headers: header }
    );
  }

  loginUserWithOutHttpHeader(user: LoginRequest): Observable<any> {
    console.log(user);
    return this.httpClient.post<string>(
      `${API_URL}/token/login`,
      user,
      // { email: 'email', password: 'password' },
      {
        headers: this.headers,
        responseType: 'text' as 'json',
      }
    );
  }

  loginUserWithUser(user: LoginRequest) {
    return this.httpClient.post<LoginRequest>(`${API_URL}/token/login`, user);
  }

  getToken(user: LoginRequest): Observable<any> {
    console.log(`Inside service: ${JSON.stringify(user)}`);
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    const url = `${API_URL}/token/login${JSON.stringify(user)}`;
    console.log(url);
    return this.httpClient
      .post(url, { headers: headers })
      .pipe(tap((data) => console.log('Data: ' + JSON.stringify(data))));
  }

  redirectToLogin(): void {
    this.router.navigate(['home/login']);
  }

  // private handleError(err: HttpErrorResponse): ErrorObservable {
  //   let errorMessage: string;
  //   if (err.error instanceof Error) {
  //     // A client-side or network error occurred. Handle it accordingly.
  //     errorMessage = `An error occured: ${err.error.message}`;
  //   } else {
  //     // The backend returned an unsuccessful response code.
  //     // The response body may contain clues as to what went wrong,
  //     errorMessage = `Backend returned code ${err.status}, body was: ${err.error}`;
  //   }
  //   console.error(err);
  //   return new ErrorObservable(errorMessage);
  // }
}
