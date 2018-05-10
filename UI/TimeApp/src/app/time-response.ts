import { TimeCard } from "./time-card";

export class TimeResponse {
    timeCards: TimeCard[];
    response_guid: string;
    response_timestamp: string;
    success: boolean;
    error: string;
}
