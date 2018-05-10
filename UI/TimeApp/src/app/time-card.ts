import { TimeEntry } from "./time-entry";

export class TimeCard {
    timePeriodID: number;
    payPeriodStartDate: Date;
    payPeriodEndDate: Date;
    entries: TimeEntry[];
}
