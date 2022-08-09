import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuccesregistrationComponent } from './succesregistration.component';

describe('SuccesregistrationComponent', () => {
  let component: SuccesregistrationComponent;
  let fixture: ComponentFixture<SuccesregistrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuccesregistrationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SuccesregistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
