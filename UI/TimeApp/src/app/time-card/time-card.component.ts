import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProjectsService } from '../projects.service';
import { Project } from '../project';
import { ObjectivesService } from '../objectives.service';
import { Objective } from '../objective';
import { TimeEntry } from '../time-entry';
import { TimeentryService } from '../timeentry.service';
import { TimecardService } from '../timecard.service';
import { SessionStorageService } from 'angular-web-storage';

@Component({
  selector: 'app-time-card',
  templateUrl: './time-card.component.html',
  styleUrls: ['./time-card.component.css']
})
export class TimeCardComponent implements OnInit {
  entry: TimeEntry;
  projects: Project[];
  objectives: Objective[];
  date: Date;

  myGroup = new FormGroup({
    date : new FormControl(),
    project: new FormControl(),
    objective: new FormControl(),
    hours: new FormControl(),
    comments: new FormControl()
  });

  constructor(private pService: ProjectsService,
              private oService: ObjectivesService,
              private cService: TimecardService,
              private session: SessionStorageService) {
                this.entry = new TimeEntry();
                this.entry.employeeID = this.session.get('employee').employeeID;
                this.entry.timeDate = new Date();
              }

  ngOnInit() {
    this.pService.getProjects().subscribe(items => this.projects = items);
            this.myGroup.controls['date'].setValue(
          {
            month: this.entry.timeDate.getMonth() + 1,
            day: this.entry.timeDate.getDate(),
            year: this.entry.timeDate.getFullYear()
          });
    this.onChange();
  }

  onChange(): void {
    this.myGroup.controls['project'].valueChanges.subscribe((value) => {
      if (value) {
        this.oService.getObjectives(value).subscribe(items => this.objectives = items);
      }
    });
  }

  submitTime(): void {
    console.log('Submit button was pressed.');
    // const entry = new TimeEntry();
    // entry.employeeID = 24;
    this.entry.hourTime = this.myGroup.controls['hours'].value;
    this.entry.projectID = this.myGroup.controls['project'].value;
    this.entry.specID = this.myGroup.controls['objective'].value;
    this.entry.comments = this.myGroup.controls['comments'].value;
    // entry.timeDate = new Date();
    this.entry.hourType = 41;

    console.log(this.entry);
    this.cService.putEntry(this.entry);
    this.resetForm();
  }

  resetForm() {
    this.entry = new TimeEntry();
    this.myGroup.controls['date'].setValue(
      {month: this.entry.timeDate.getMonth() + 1, day: this.entry.timeDate.getDate(), year: this.entry.timeDate.getFullYear()}
    );
    this.myGroup.controls['project'].setValue(this.entry.projectID);
    this.myGroup.controls['objective'].setValue(this.entry.specID);
    this.myGroup.controls['hours'].setValue(this.entry.hourTime);
    this.myGroup.controls['comments'].setValue(this.entry.comments);
  }

  editEntry(entry: TimeEntry) {
    this.entry = entry;
    console.log('Should be editing entry: ' + entry.timeID + ' in form...');
    entry.timeDate = new Date(entry.timeDate);
    this.myGroup.controls['date'].setValue(
      {month: entry.timeDate.getMonth() + 1, day: entry.timeDate.getDate(), year: entry.timeDate.getFullYear()}
    );
    this.myGroup.controls['project'].setValue(entry.projectID);
    this.myGroup.controls['objective'].setValue(entry.specID);
    this.myGroup.controls['hours'].setValue(entry.hourTime);
    this.myGroup.controls['comments'].setValue(entry.comments);
  }
}
