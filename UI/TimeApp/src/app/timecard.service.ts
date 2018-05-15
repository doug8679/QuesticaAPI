import { Injectable } from '@angular/core';
import { TimeCard } from './time-card';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { TimeResponse } from './time-response';
import { TimeEntry } from './time-entry';

@Injectable({
  providedIn: 'root'
})
export class TimecardService {

  cards: TimeCard[];

  constructor(private http: HttpClient) { }

  getCards(id: number): Observable<TimeCard[]> {
    if (!this.cards) {
      return this.http.get('http://localhost:5001/api/time/' + id)
        .pipe(
          map((obj: TimeResponse) => this.cards = obj.timeCards),
          tap(obj => {
            console.log(obj);
            console.log(this.cards);
          })
        );
    } else {
      return of(this.cards);
    }
  }

  putEntry(entry: TimeEntry): void {
    if (this.cards[0].entries.find(e => e.timeID === entry.timeID)) {
      console.log('updating existing entry...');
      this.http.post('http://localhost:5001/api/time/entry', entry).subscribe(response => console.log(response));
    } else {
      // Eventually, we'll send this to the WebAPI.  For now, just add it to the list of entries...
      this.http.put('http://localhost:5001/api/time/entry', entry).subscribe(response => console.log(response));
      this.cards[0].entries.push(entry);
    }
  }
}
