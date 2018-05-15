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

  entryUrl = 'http://localhost:5001/api/time/24';
  entries: TimeEntry[];

  constructor(private http: HttpClient) { }

  getEntries(): Observable<TimeEntry[]> {
    if (!this.entries) {
      return this.http.get(this.entryUrl)
        .pipe(
          map((obj: TimeResponse) => {
            this.entries = obj.timeCards[0].entries;
            return this.entries;
          }),
          tap(obj => {
            console.log(obj);
            console.log(this.entries);
          })
        );
    } else {
      return of(this.entries);
    }
  }

  putEntry(entry: TimeEntry) {
    // Eventually, we'll send this to the WebAPI.  For now, just add it to the list of entries...
    this.http.put('http://localhost:5001/api/time/entry', entry).subscribe(response => console.log(response));
    this.entries.push(entry);
  }

  deleteEntry(entryId: number): void {
    console.log('Service will attempt to delete entry ' + entryId + ' via WebAPI');
    this.http.delete('http://localhost:5001/api/time/entry/' + entryId).subscribe(response => console.log(response));
  }
}
