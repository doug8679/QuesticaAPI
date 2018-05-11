import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { AngularWebStorageModule } from 'angular-web-storage';

import { AppComponent } from './app.component';
import { ObjectivesService } from './objectives.service';
import { ProjectsService } from './projects.service';
import { TimecardService } from './timecard.service';
import { TimeentryService } from './timeentry.service';
import { TimeCardComponent } from './time-card/time-card.component';
import { TimeReportComponent } from './time-report/time-report.component';
import { LoginComponent } from './login/login.component';

const appRoutes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'time-entry', component: TimeCardComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    TimeCardComponent,
    TimeReportComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    AngularWebStorageModule,
    RouterModule.forRoot(appRoutes, { enableTracing: true})
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
