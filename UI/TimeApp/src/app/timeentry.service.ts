import { Injectable } from '@angular/core';
import { TimeEntry } from './time-entry';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import { TimeResponse } from './time-response';

@Injectable({
  providedIn: 'root'
})
export class TimeentryService {

  entryUrl: string = "http://localhost:5001/api/time/24";
  entries: TimeEntry[];

  constructor(private http: HttpClient) { }

  getEntries(): Observable<TimeEntry[]> {
    if (!this.entries){
      return this.http.get(this.entryUrl)
        .pipe(
          map((obj: TimeResponse) => {
            this.entries = obj.timeCards[0].entries;
            return this.entries;
          }),
          tap(obj => {
            console.log(obj);
            console.log(this.entries)
          })
        );
    } else {
      return of(this.entries);
    }
  }
}
