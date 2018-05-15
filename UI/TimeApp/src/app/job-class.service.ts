import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { JobCode } from './job-code';
import { HttpClient } from '@angular/common/http';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class JobClassService {

  jobs: JobCode[];

  constructor(private http: HttpClient) { }

  getJobCodes(): Observable<JobCode[]> {
    if (!this.jobs) {
      return this.http.get<JobCode[]>('http://localhost:5001/api/job-codes')
        .pipe(
          map((response: any) => this.jobs = response.jobCodes.filter(j => j.hourActive))
        );
    } else {
      return of(this.jobs);
    }
  }
}
