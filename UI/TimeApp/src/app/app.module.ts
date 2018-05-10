import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ObjectivesService } from './objectives.service';
import { ProjectsService } from './projects.service';
import { TimecardService } from './timecard.service';
import { TimeentryService } from './timeentry.service';
import { TimeCardComponent } from './time-card/time-card.component';
import { TimeReportComponent } from './time-report/time-report.component';

@NgModule({
  declarations: [
    AppComponent,
    TimeCardComponent,
    TimeReportComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule
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
