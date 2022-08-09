import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Tracking } from 'src/app/models/tracking';
import { TrackingsService } from 'src/app/services/trackings.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss'],
})
export class TableComponent implements OnInit {
  trackingsList: Tracking[] = [];
  newTracking: Tracking = {};
  searchTracking: Tracking = {};
  newUpdateTracking: Tracking = {};

  searchTerm = '';
  term = '';

  country = '';
  startDate = '';
  endDate = '';
  state = '';

  displayedColumns: string[] = [
    'name',
    'description',
    'date',
    'numberofhours',
    'operations',
  ];
  dataSource: Tracking[] = [];

  constructor(
    private trackigsService: TrackingsService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.trackigsService.getTrackings().subscribe((trackings) => {
      this.dataSource = trackings;
      console.log(this.dataSource);
    });
  }

  // logout() {
  //   localStorage.removeItem('jwt');
  //   this.router.navigate(['/home/login']);
  // }

  filterTracking(tracking: Tracking) {
    this.trackigsService.filterTrackings(tracking).subscribe((trackings) => {
      this.dataSource = trackings;
      console.log(this.dataSource);
    });
  }

  addTracking() {
    this.trackigsService
      .addTrackings(this.newTracking)
      .subscribe((tracking) => {
        this.dataSource = [...this.dataSource, tracking];
        this.newTracking = {};
      });
  }

  deleteTracking(tracking: Tracking) {
    this.trackigsService.deleteTrackings(tracking).subscribe(() => {
      this.dataSource = this.dataSource.filter(
        (item) => item.id !== tracking.id
      );
    });
  }

  getTrackings() {
    this.trackigsService.getTrackings().subscribe((trackings) => {
      this.dataSource = trackings;
    });
  }

  sendParamsCountry() {
    this.router.navigate(['table/country', this.country]);
  }
  sendParamsState() {
    this.router.navigate([
      'table/state',
      this.state,
      this.startDate,
      this.endDate,
    ]);
  }

  // updateTracking(tracking: Tracking) {
  //   console.log(tracking);
  //   tracking.isEditing = false;
  //   this.trackigsService.updateTrackings(tracking.id, tracking).subscribe(() => {
  //     this.dataSource = this.dataSource.map((item) =>
  //       item.id === tracking.id ? tracking : item
  //     );
  //   });
  // }
}
