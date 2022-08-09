import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { SubActivity } from 'src/app/models/SubActivity';
import { Tracking } from 'src/app/models/tracking';
import { TrackingsService } from 'src/app/services/trackings.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss'],
})
export class UpdateComponent implements OnInit {
  subactivities: SubActivity[] = [];
  dataSource?: Tracking;
  private currentActivityId?: number;
  private routeSub: Subscription = new Subscription();

  constructor(
    private formBuilder: FormBuilder,
    private trackigsService: TrackingsService,
    private route: ActivatedRoute,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.routeSub = this.route.params.subscribe((params) => {
      this.currentActivityId = params['id'];
      if (this.currentActivityId) {
        this.trackigsService
          .getTrackingsById(this.currentActivityId)
          .subscribe((tracking: Tracking) => {
            this.trackingForm.patchValue(tracking);
            this.subactivities = tracking.subActivities
              ? tracking.subActivities
              : [];
          });
      }
    });
  }

  trackingForm = this.formBuilder.group({
    name: ['', [Validators.required, Validators.minLength(3)]],
    description: [''],
    date: [''],
    numberOfHours: [],
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

  subActivityForm = this.formBuilder.group({
    description: ['', [Validators.required]],
    numberOfHours: ['', [Validators.required, Validators.min(0)]],
    dificulty: ['', [Validators.required]],
  });

  get subActivityDescription() {
    return this.subActivityForm.get('description');
  }

  get subActivityNumbersOfHours() {
    return this.subActivityForm.get('numbersOfHours');
  }

  get subActivityDifficulty() {
    return this.subActivityForm.get('difficulty');
  }

  // updateTracking(tracking: Tracking) {
  //   console.log(tracking);
  //   this.trackigsService.updateTrackings(tracking).subscribe(() => {
  //     this.dataSource = this.dataSource.map((item) =>
  //       item.id === tracking.id ? tracking : item
  //     );
  //   });
  // }

  onSubmit() {
    let activity = this.trackingForm.value;
    activity.subActivities = this.subactivities;
    activity.id = this.currentActivityId;
    if (this.currentActivityId) {
      this.trackigsService
        .updateTrackings(this.currentActivityId, activity)
        .subscribe(() => {
          this.openSnackBar();
        });
    }
  }

  onSubactivitySubmit() {
    this.subactivities.push(this.subActivityForm.value);
    this.subActivityForm.reset();
  }

  openSnackBar() {
    this._snackBar.open('Activity updated successfuly!!', 'close', {
      horizontalPosition: 'center',
      verticalPosition: 'top',
      duration: 5000,
    });
  }

  deleteSubActivity(subactivity: SubActivity) {
    this.subactivities = this.subactivities.filter((s) => s !== subactivity);
  }
}
