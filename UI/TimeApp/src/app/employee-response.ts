import { BaseResponse } from './base-response';
import { Employee } from './employee';

export class EmployeeResponse extends BaseResponse {
    employee: Employee;
}
