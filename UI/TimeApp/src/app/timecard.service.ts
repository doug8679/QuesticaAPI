import { Injectable } from '@angular/core';
import { TimeCard } from './time-card';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { TimeResponse } from './time-response';

@Injectable({
  providedIn: 'root'
})
export class TimecardService {

  cards: TimeCard[];

  constructor(private http: HttpClient) { }

  getCards(): Observable<TimeCard[]>{
    if (!this.cards) {
      return this.http.get("http://localhost:5001/api/time/24")
        .pipe(
          map((obj: TimeResponse) => this.cards = obj.timeCards),
          tap(obj=> {
            console.log(obj);
            console.log(this.cards);
          })
        );
    } else {
      return of(this.cards);
    }
  }
}
