import { TestBed, inject } from '@angular/core/testing';

import { JobClassService } from './job-class.service';

describe('JobClassService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [JobClassService]
    });
  });

  it('should be created', inject([JobClassService], (service: JobClassService) => {
    expect(service).toBeTruthy();
  }));
});
