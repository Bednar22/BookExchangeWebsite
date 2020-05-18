import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { FormBuilder, FormControl } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  registerForm: any;
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private alertify: AlertifyService
  ) {
    this.registerForm = this.formBuilder.group({
      username: new FormControl(),
      password: new FormControl(),
    });
  }

  ngOnInit(): void {}

  register() {
    this.model.username = this.registerForm.value.username;
    this.model.password = this.registerForm.value.password;
    this.authService.register(this.model).subscribe(
      () => {
        this.alertify.success('Register done successfully');
      },
      (error) => {
        this.alertify.error('Register failed');
      }
    );
    this.registerForm.reset();
  }
  cancel() {
    this.cancelRegister.emit(false);
    console.log('Canceled!');
  }
}
