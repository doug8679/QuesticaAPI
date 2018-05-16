export class TimeEntry {
    timeID: number;
    timePeriodID: number;
    timeDate: Date;
    projectID: number;
    specID: number;
    hourType: number;
    hourTime: number;
    hourRate: number;
    employeeID: number;
    empNumber: string;
    comments: string;

    hourClass: string;
    hourFactor: number;

    constructor() {
        this.timeDate = new Date();
        this.hourClass = 'Regular';
        this.hourFactor = 1.0;
    }
}
