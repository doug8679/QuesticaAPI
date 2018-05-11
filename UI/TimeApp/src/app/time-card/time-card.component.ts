import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProjectsService } from '../projects.service';
import { Project } from '../project';
import { ObjectivesService } from '../objectives.service';
import { Objective } from '../objective';
import { TimeEntry } from '../time-entry';
import { TimeentryService } from '../timeentry.service';
import { TimecardService } from '../timecard.service';

@Component({
  selector: 'app-time-card',
  templateUrl: './time-card.component.html',
  styleUrls: ['./time-card.component.css']
})
export class TimeCardComponent implements OnInit {

  projects: Project[];
  objectives: Objective[];

  myGroup = new FormGroup({
    project: new FormControl(),
    objective: new FormControl(),
    hours: new FormControl(),
    comments: new FormControl()
  });

  constructor(private pService: ProjectsService,
              private oService: ObjectivesService,
              private cService: TimecardService) {}

  ngOnInit() {
    this.pService.getProjects().subscribe(items => this.projects = items);

    this.onChange();
  }

  onChange(): void {
    this.myGroup.controls['project'].valueChanges.subscribe((value) => {
      console.log(value);
      this.oService.getObjectives(value).subscribe(items => this.objectives = items);
    });
  }

  submitTime(): void {
    console.log('Submit button was pressed.');
    const entry = new TimeEntry();
    entry.employeeID = 24;
    entry.hourTime = this.myGroup.controls['hours'].value;
    entry.projectID = this.myGroup.controls['project'].value;
    entry.specID = this.myGroup.controls['objective'].value;
    entry.comments = this.myGroup.controls['comments'].value;
    entry.timeDate = new Date();
    entry.hourType = 41;

    console.log(entry);
    this.cService.putEntry(entry);
  }

}
