import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProjectsService } from './projects.service';
import { Project } from './project';
import { SessionStorageService } from 'angular-web-storage';
import { Router } from '@angular/router';
import { JobClassService } from './job-class.service';
import { JobCode } from './job-code';
import { Employee } from './employee';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Welcome to TimeCard V2!';

  jobCodeForm = new FormGroup({
    jobCode: new FormControl()
  });
  myJobCode = '';
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

    this.jobCodeForm.controls['jobCode'].setValue(this.session.get('jobCode'));
    this.jobCodeForm.controls['jobCode'].valueChanges.subscribe((value: JobCode) => {
      this.session.set('jobCode', value);
    });

    this.makeTitle();
  }

  makeTitle() {
    const emp: Employee = this.session.get('employee');
    if (emp) {
      this.title = 'Welcome, ' + emp.empFirstName + '!';
    }
  }

  compareFn(c1: JobCode, c2: JobCode): boolean {
    return c1 && c2 ? c1.hourID === c2.hourID : c1 === c2;
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

  doLogout(): void {
    this.session.remove('jobCodes');
    this.session.remove('employee');
    this.title = 'Welcome to TimeCard V2!';
    this.router.navigate(['/']);
  }

  isLoggedIn(): boolean {
    this.getJobCodes();
    return this.session.get('employee');
  }
}
