import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormBuilder, Validators } from '@angular/forms';
import { TrackingsService } from 'src/app/services/trackings.service';
import { Tracking } from 'src/app/models/tracking';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss'],
})
export class DetailsComponent implements OnInit {
  private routeSub: Subscription = new Subscription();

  constructor(
    private formBuilder: FormBuilder,
    private trackigsService: TrackingsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    // const idFromUrl = this.activatedRoute.snapshot.paramMap.get('id');
    // console.log(idFromUrl);

    // this.trackigsService
    //   .getTrackingsById(idFromUrl)
    //   .subscribe((trackingItem) => {
    //     this.dataSource = trackingItem;
    //     console.log(trackingItem);
    //   });

    this.routeSub = this.route.params.subscribe((params) => {
      const id = params['id'] as number;
      this.trackigsService
        .getTrackingsById(id)
        .subscribe((tracking: Tracking) => {
          this.dataSource = tracking;
        });
    });
  }

  displayedColumns: string[] = ['name', 'description', 'date', 'numberofhours'];

  dataSource?: Tracking;

  trackingForm = this.formBuilder.group({
    name: ['', [Validators.required, Validators.minLength(3)]],
    description: [''],
    date: [''],
    numberOfHours: [''],
    subActivities: [''],
  });

  get name() {
    return this.trackingForm.get('name');
  }

  get description() {
    return this.trackingForm.get('description');
  }

  get date() {
    return this.trackingForm.get('date');
  }

  get numberOfHours() {
    return this.trackingForm.get('numberOfHours');
  }

  deleteTracking(tracking: Tracking) {}
  updateTracking(tracking: Tracking) {}

  getTrackingsByIdComponent(tracking: Tracking) {}
}
