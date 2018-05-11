import { Component } from '@angular/core';
import { ProjectsService } from './projects.service';
import { Project } from './project';
import { SessionStorageService } from 'angular-web-storage';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  projects: Project[];

  constructor(private service: ProjectsService,
              private session: SessionStorageService,
              private router: Router) { }

  ngOnInit() {
    let proj = this.session.get('projects');
    if (!proj) {
      this.service.getProjects().subscribe(items => {
        proj = items;
        this.session.set('projects', proj);
      });
    }
  }

  doLogout(): void {
    this.session.remove('employee');
    this.router.navigate(['/']);
  }
}
