import { Component, OnInit } from '@angular/core';
import { TimeCard } from '../time-card';
import { TimeEntry } from '../time-entry';
import { TimeentryService } from '../timeentry.service';
import { TimecardService } from '../timecard.service';

@Component({
  selector: 'app-time-report',
  templateUrl: './time-report.component.html',
  styleUrls: ['./time-report.component.css']
})
export class TimeReportComponent implements OnInit {

  card: TimeCard = new TimeCard();
  entries: TimeEntry[];

  constructor(private cService: TimecardService,
              private eService: TimeentryService) { }

  ngOnInit() {
    this.cService.getCards().subscribe(items => {
      console.log(items);
      this.card = items[0];
      this.entries = this.card.entries;
    });
  }

  deleteEntry(entryId: number){
    console.log('Attempting to delete time entry: ' + entryId);
    this.eService.deleteEntry(entryId);
  }

  editEntry(entry: TimeEntry): void {
    console.log('Editing entry: ' + entry.timeID + ' in editor...');
  }

}
