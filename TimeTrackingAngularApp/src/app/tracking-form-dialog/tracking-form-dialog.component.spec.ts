import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrackingFormDialogComponent } from './tracking-form-dialog.component';

describe('TrackingFormDialogComponent', () => {
  let component: TrackingFormDialogComponent;
  let fixture: ComponentFixture<TrackingFormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrackingFormDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TrackingFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
