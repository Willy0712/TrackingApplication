import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Subscription } from 'rxjs';
import { CountryFilter } from 'src/app/models/CountryFilter';
import { ObservableService } from 'src/app/services/observable.service';

@Component({
  selector: 'app-country-details',
  templateUrl: './country-details.component.html',
  styleUrls: ['./country-details.component.scss'],
})
export class CountryDetailsComponent implements OnInit {
  @Output() newItemEvent = new EventEmitter<string>();

  addNewItem(value: string) {
    this.newItemEvent.emit(value);
  }

  constructor(private data: ObservableService) {}

  ngOnInit(): void {}

  // submit() {
  //   console.log(this.approvalText);
  //   this.data.updateApprovalMessage(this.approvalText);
  // }
}
