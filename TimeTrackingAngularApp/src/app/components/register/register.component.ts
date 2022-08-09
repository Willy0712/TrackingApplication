import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { SignupRequest } from 'src/app/models/SignupRequest';
import { SignupService } from 'src/app/services/signup.service';
import { LoginComponent } from '../login/login.component';
import { SuccesregistrationComponent } from './succesregistration/succesregistration.component';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  credentials: SignupRequest = {
    firstName: '',
    lastName: '',
    userName: '',
    email: '',
    password: '',
  };

  ngOnInit(): void {}
  constructor(private router: Router, private signUpService: SignupService) {}

  login(form: NgForm) {
    const headersParam: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    // const userInfo = {username:this.logInForm.get('username')?.value, password:this.logInForm.get('password')?.value}
    this.signUpService.signUpUser(this.credentials).subscribe((response) => {
      console.log(response);
      this.router.navigate([
        'home/register/succesregistration',
        this.credentials.email,
      ]);
    });
  }
}
