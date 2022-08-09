import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticatedResponse } from 'src/app/models/AuthenticatedResponse';
import { LoginRequest } from 'src/app/models/LoginRequest';
import { LoginService } from 'src/app/services/login.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean = false;
  credentials: LoginRequest = { email: '', password: '' };

  constructor(
    private router: Router,
    private loginService: LoginService,
    private http: HttpClient,
    private location: Location
  ) {}

  ngOnInit(): void {}

  //  LOGIN WITH HTTP HEADER AND SERVICE

  //   login(form: NgForm) {
  //     const headersParam: HttpHeaders = new HttpHeaders({
  //       'Content-Type': 'application/json',
  //     });

  //     if (form.valid) {
  //       console.log(this.credentials);
  //       this.loginService.loginUserWithOutHttpHeader(this.credentials).subscribe({
  //         next: (response) => {
  //           console.log(response);
  //           console.debug(`logged in successfully ${response}`);
  //           const token = response.token;
  //           console.log(response.token);
  //           localStorage.setItem('jwt', token);
  //           this.invalidLogin = false;
  //           this.router.navigate(['/table']);
  //         },
  //         // error: (err: HttpErrorResponse) => (this.invalidLogin = true),
  //       });
  //     }
  //   }
  // }

  //   login(form: NgForm) {
  //     const headersParam: HttpHeaders = new HttpHeaders({
  //       'Content-Type': 'application/json',
  //     });
  //     // const userInfo = {username:this.logInForm.get('username')?.value, password:this.logInForm.get('password')?.value}
  //     this.http
  //       .post(
  //         'https://localhost:7220/api/token/login',
  //         this.credentials,
  //         { headers: headersParam, observe: 'response' },
  //         {responseType: 'text' as 'json'}
  //       )
  //       .subscribe({
  //         next: (res) => {
  //           const token = res.headers.get('Authorization');
  //           const authority = res.headers.get('Authority');
  //           const granted = res.headers.get('Granted');
  //           console.log(token);
  //           console.log(authority);
  //           console.log(granted);
  //           if (token != null && authority != null && granted != null) {
  //             localStorage.setItem('Authorization', token);
  //             this.router.navigate(['/table']);
  //             // this.currentUser.setUser(authority);
  //             // this.currentUser.setRoles(granted);
  //             // console.log(this.currentUser.getRoles());
  //           }
  //         },
  //       });
  //   }
  // }

  //  LOGIN WITH GETTOKEN

  //   login(form: NgForm) {
  //     const headersParam: HttpHeaders = new HttpHeaders({
  //       'Content-Type': 'application/json',
  //     });

  //     if (form.valid) {
  //       console.log(this.credentials);
  //       this.loginService.getToken(this.credentials).subscribe(
  //         (response) => {
  //           console.log(`token is ${response}`);
  //           console.debug(`logged in successfully ${response}`);
  //           localStorage.setItem('token', response.token);
  //           localStorage.setItem('tokenexpiration', response.expiration);
  //           // const token = response.token;
  //           // console.log(response.token);
  //           // localStorage.setItem('jwt', token);
  //           this.invalidLogin = false;
  //           this.router.navigate(['/table']);
  //         }
  //         // error: (err: HttpErrorResponse) => (this.invalidLogin = true),
  //       );
  //     }
  //   }
  // }

  // LOGIN FUNCTIONAL ONE

  login = (form: NgForm) => {
    const headersParam: HttpHeaders = new HttpHeaders({
      'Content-Type': 'application/json',
    });
    if (form.valid) {
      this.http
        .post<string>(
          'https://localhost:7220/api/token/login',
          this.credentials,
          {
            headers: new HttpHeaders({
              'Content-Type': 'application/json',
            }),
            responseType: 'text' as 'json',
          }
        )
        .subscribe({
          next: (response) => {
            const token = response;
            const authToken = 'Bearer ' + token;
            localStorage.setItem('jwt', token);
            console.log(localStorage.getItem('jwt'));
            this.invalidLogin = false;
            this.router.navigate(['/table']);
            // this.location.back();

            // const lastNav = this.router.getLastSuccessfulNavigation();

            // const previousRoute = lastNav.previousNavigation;

            // this.router.navigateByUrl(previousRoute);
          },
          error: (err: HttpErrorResponse) => (this.invalidLogin = true),
        });
    }
  };
}

//   login = (form: NgForm) => {
//     const headersParam: HttpHeaders = new HttpHeaders({
//       'Content-Type': 'application/json',
//     });
//     if (form.valid) {
//       this.http
//         .post<string>(
//           'https://localhost:7220/api/token/login',
//           this.credentials,
//           {
//             headers: new HttpHeaders({
//               'Content-Type': 'application/json',
//             }),
//             responseType: 'text' as 'json',
//           }
//         )
//         .subscribe({
//           next: (response) => {
//             const token = response;
//             const authToken = 'Bearer ' + token;
//             localStorage.setItem('jwt', token);
//             console.log(localStorage.getItem('jwt'));
//             this.invalidLogin = false;
//             this.router.navigate(['/table']);
//           },
//           // error: (err: HttpErrorResponse) => (this.invalidLogin = true),
//         });
//     }
//   };
// }
