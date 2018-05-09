import { TestBed, inject } from '@angular/core/testing';

import { TimecardService } from './timecard.service';

describe('TimecardService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TimecardService]
    });
  });

  it('should be created', inject([TimecardService], (service: TimecardService) => {
    expect(service).toBeTruthy();
  }));
});
