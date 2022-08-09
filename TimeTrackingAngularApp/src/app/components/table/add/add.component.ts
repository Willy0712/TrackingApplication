import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { TrackingsService } from 'src/app/services/trackings.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SubActivity } from 'src/app/models/SubActivity';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss'],
})
export class AddComponent implements OnInit {
  subactivities: SubActivity[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private trackingService: TrackingsService,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {}

  trackingForm = this.formBuilder.group({
    name: ['', [Validators.required, Validators.minLength(3)]],
    description: [''],
    date: [''],
    numberOfHours: [''],
    //subActivities: [''],
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

  onSubmit() {
    let tracking = this.trackingForm.value;
    tracking.subActivities = this.subactivities;
    this.trackingService.addTrackings(this.trackingForm.value).subscribe(() => {
      this.subactivities = [];
      this._snackBar.open('Added successfully!', 'Ok', {
        verticalPosition: 'top',
        duration: 6 * 1000,
      });

      this.trackingForm.reset();
    });
  }

  onSubactivitySubmit() {
    this.subactivities.push(this.subActivityForm.value);
    console.log(this.subActivityForm.value);
    this.subActivityForm.reset();
  }

  deleteSubActivity(subactivity: SubActivity) {
    this.subactivities = this.subactivities.filter((s) => s !== subactivity);
  }
}
