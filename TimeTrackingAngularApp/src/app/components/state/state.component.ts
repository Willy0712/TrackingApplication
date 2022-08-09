import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { StateFilter } from 'src/app/models/StateFilter';
import { TrackingsService } from 'src/app/services/trackings.service';

@Component({
  selector: 'app-state',
  templateUrl: './state.component.html',
  styleUrls: ['./state.component.scss'],
})
export class StateComponent implements OnInit {
  private currentState = '';
  private currentStartDate = '';
  private currentEnddate = '';
  private routeSub = new Subscription();
  dataSource: StateFilter[] = [];
  constructor(
    private trackingService: TrackingsService,
    private route: ActivatedRoute
  ) {}

  displayedColumns: string[] = [
    'name',
    'description',
    'date',
    'numberofhours',
    'stateName',
  ];

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe((params) => {
      this.currentState = params['state'];
      this.currentStartDate = params['startDate'];
      this.currentEnddate = params['endDate'];
      console.log(
        this.currentState,
        this.currentStartDate,
        this.currentEnddate
      );
      this.trackingService
        .getFilteredByCityAndDate(
          this.currentState,
          this.currentStartDate,
          this.currentEnddate
        )
        .subscribe((tracking) => {
          this.dataSource = tracking;
          console.log(tracking);
        });
    });
  }
}
