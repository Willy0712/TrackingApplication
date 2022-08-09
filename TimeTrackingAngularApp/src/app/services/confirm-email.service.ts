import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_URL } from '../constants';

@Injectable({
  providedIn: 'root',
})
export class ConfirmEmailService {
  constructor(private httpClient: HttpClient) {}

  addEmail(email: string) {
    return this.httpClient.post(
      `${API_URL}/token/register/confrimEmail?email=${email}`,
      email
    );
  }
}
