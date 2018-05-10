import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { Project } from './project';

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  projectUrl: string = "http://localhost:5001/api/projects";

  projects: Project[];

  constructor(private http: HttpClient) { }

  getProjects(): Observable<Project[]> {
    if (!this.projects) {
      return this.http.get<Project[]>(this.projectUrl)
        .pipe(
          tap(items=> this.projects = items)
        );
    } else {
      return of(this.projects);
    }
  }
}
