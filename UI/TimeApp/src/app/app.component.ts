import { Component, OnInit } from '@angular/core';
import { ProjectsService } from './projects.service';
import { Project } from './project';
import { SessionStorageService } from 'angular-web-storage';
import { Router } from '@angular/router';
import { JobClassService } from './job-class.service';
import { JobCode } from './job-code';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'app';

  job: JobCode[];
  projects: Project[];

  constructor(private service: ProjectsService,
              private jService: JobClassService,
              public session: SessionStorageService,
              private router: Router) { }

  ngOnInit() {
    let proj = this.session.get('projects');
    if (!proj) {
      this.service.getProjects().subscribe(items => {
        proj = items;
        this.session.set('projects', proj);
      });
    }

    this.getJobCodes();
  }

  getJobCodes() {
    this.job = this.session.get('jobCodes');
    if (!this.job) {
      this.jService.getJobCodes().subscribe(items => {
        this.job = items;
        this.session.set('jobCodes', this.job);
      });
    }
  }

  jobCodeChanged(jobCode) {
    console.log('Job code was changed to: ' + jobCode);
    this.session.set('jobCode', this.job.find(j => j.hourID === jobCode));
  }

  doLogout(): void {
    this.session.remove('jobCodes');
    this.session.remove('employee');
    this.router.navigate(['/']);
  }

  isLoggedIn(): boolean {
    this.getJobCodes();
    return this.session.get('employee');
  }
}
