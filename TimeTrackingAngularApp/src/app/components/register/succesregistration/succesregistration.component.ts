import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ConfirmEmailService } from 'src/app/services/confirm-email.service';

@Component({
  selector: 'app-succesregistration',
  templateUrl: './succesregistration.component.html',
  styleUrls: ['./succesregistration.component.scss'],
})
export class SuccesregistrationComponent implements OnInit {
  constructor(
    private routeActivated: ActivatedRoute,
    private confirmEmailService: ConfirmEmailService,
    private router: Router
  ) {}

  private searchTerm = '';
  private routeSub: Subscription = new Subscription();

  ngOnInit(): void {
    this.routeSub = this.routeActivated.params.subscribe((params) => {
      this.searchTerm = params['email'];
      console.log(this.searchTerm);
    });
  }

  confirmEmail() {
    console.log(this.searchTerm);
    this.confirmEmailService.addEmail(this.searchTerm).subscribe((response) => {
      this.router.navigate(['/home/login']);
    });
  }
}
