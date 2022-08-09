import { TestBed } from '@angular/core/testing';

import { SubactivityService } from './subactivity.service';

describe('SubactivityService', () => {
  let service: SubactivityService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SubactivityService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
