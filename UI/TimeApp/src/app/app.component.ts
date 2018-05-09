import { Component } from '@angular/core';
import { ProjectsService } from './projects.service';
import { Project } from './project';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  projects: Project[];

  constructor(private service: ProjectsService){}

  ngOnInit() {
    this.service.getProjects().subscribe(items => {this.projects = items;});
  }
}
