import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_URL } from '../constants';
import { SignupRequest } from '../models/SignupRequest';

@Injectable({
  providedIn: 'root',
})
export class SignupService {
  constructor(private httpClient: HttpClient) {}

  signUpUser(user: SignupRequest) {
    return this.httpClient.post(`${API_URL}/token/register`, user);
  }
}
