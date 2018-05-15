import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { Objective } from './objective';

@Injectable({
  providedIn: 'root'
})
export class ObjectivesService {

  objectiveUrl = 'http://localhost:5001/api/projects/';

  projectId: number;
  objectives: Objective[];

  constructor(private http: HttpClient) { }

  getObjectives(projectId): Observable<Objective[]> {
    console.log('Loading objectives for projectId: ' + projectId);
    if (!this.objectives || this.projectId !== projectId) {
      this.projectId = projectId;
      const url = this.objectiveUrl + projectId;
      return this.http.get<Objective[]>(url)
        .pipe(
          tap(items => this.objectives = items)
        );
    } else {
      return of(this.objectives);
    }
  }
}
