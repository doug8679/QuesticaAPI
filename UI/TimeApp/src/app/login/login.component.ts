import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { SessionStorageService } from 'angular-web-storage';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  welcome = 'Login To Time Card:';

  loginGroup = new FormGroup({
    username: new FormControl(),
    password: new FormControl()
  });

  constructor(private http: HttpClient,
              public session: SessionStorageService,
              private router: Router) { }

  ngOnInit() {
    const emp = this.session.get('employee');
    if (emp) {
      this.welcome = 'Welcome back, ' + emp.empFirstName + '!';
      this.router.navigate(['/time-entry']);
    }
  }

  doLogin(): void {
    const body = {
      username: this.loginGroup.controls['username'].value,
      passwd: this.encryptString(this.loginGroup.controls['password'].value)
    };
    console.log('Sending login request: ');
    console.log(body);
    console.log('Attempting to log into the time card app...');
    this.http.post('http://localhost:5001/api/login', body).subscribe(response => {
      this.session.set('employee', response.employee);
      console.log(this.session.get('employee'));
      // Send to input screen...
      this.router.navigate(['/time-entry']);
    });
  }

  encryptString(value: string): string {
    value = value.padEnd(0x19);
    length = value.length;
    let buff: number[] = [length];
    const num2 = 150;
    const num3 = 0x9b;
    const num4 = 0xcf;
    const num5 = 0x95;
    let i: number, j: number, k: number, m: number;
    for (i = 0; i < length; i++) {
      buff[i] = value.charCodeAt(i);
    }
    for (i = 1; i < length; i++) {
      buff[i] = ((buff[i] ^ ((buff[i - 1] ^ ((num2 * buff[i - 1])) >>> 0) % 0x100)));
    }
    for (j = length - 2; j >= 0; j--) {
      buff[j] = ((buff[j] ^ ((buff[j + 1] ^ (((num3 * buff[j + 1]) >>> 0) % 0x100)))));
    }
    for (k = 2; k < length; k++) {
      buff[k] = ((buff[k] ^ ((buff[k - 2] ^ ((num4 * buff[k - 1]) >>> 0) % 0x100))));
    }
    for (m = length - 3; m >= 0; m--) {
      buff[m] = ((buff[m] ^ ((buff[m + 2] ^ ((num5 * buff[m + 1]) >>> 0) % 0x100))));
    }
    return btoa(String.fromCharCode.apply(null, buff));
  }
}
