import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';
import { FormControl, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
})
export class NavbarComponent implements OnInit {
  model: any = {};
  loginForm: any;
  public href: string = '';

  constructor(
    public authService: AuthService,
    private alertify: AlertifyService,
    private router: Router,
    private formBuilder: FormBuilder
  ) {
    this.loginForm = this.formBuilder.group({
      username: new FormControl(),
      password: new FormControl(),
    });
  }

  ngOnInit() {}

  login() {
    this.model.username = this.loginForm.value.username;
    this.model.password = this.loginForm.value.password;
    this.authService.login(this.model).subscribe(
      (next) => {
        this.alertify.success('Logged in to application');
      },
      (error) => {
        this.alertify.error('Logging problem');
      }
    );
    this.loginForm.reset();
  }

  loggedIn() {
    return this.authService.loggedIn();
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('Logged out!');
  }
}
