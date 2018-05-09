import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ObjectivesService } from './objectives.service';
import { ProjectsService } from './projects.service';
import { TimecardService } from './timecard.service';
import { TimeentryService } from './timeentry.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    ObjectivesService,
    ProjectsService,
    TimecardService,
    TimeentryService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
