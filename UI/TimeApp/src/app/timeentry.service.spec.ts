import { TestBed, inject } from '@angular/core/testing';

import { TimeentryService } from './timeentry.service';

describe('TimeentryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TimeentryService]
    });
  });

  it('should be created', inject([TimeentryService], (service: TimeentryService) => {
    expect(service).toBeTruthy();
  }));
});
