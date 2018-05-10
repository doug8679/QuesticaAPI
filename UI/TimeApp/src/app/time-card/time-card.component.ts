import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProjectsService } from '../projects.service';
import { Project } from '../project';
import { ObjectivesService } from '../objectives.service';
import { Objective } from '../objective';

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
  })

  constructor(private pService: ProjectsService,
              private oService: ObjectivesService) {}

  ngOnInit() {
    this.pService.getProjects().subscribe(items => this.projects = items);

    this.onChange();
  }

  onChange(): void {
    this.myGroup.controls['project'].valueChanges.subscribe((value)=> {
      console.log(value);
      this.oService.getObjectives(value).subscribe(items=> this.objectives=items);
    });
  }

}
