import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_Service/Auth.service';
import { AlertifyService } from '../_Service/Alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './Nav.component.html',
  styleUrls: ['./Nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService, private alerttify: AlertifyService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alerttify.success('Log in Success');
    }, error => {
      this.alerttify.error(error);
    });
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  loggedOut() {
    const token = localStorage.removeItem('token');
    this.alerttify.message('Logged Out');
  }

}
