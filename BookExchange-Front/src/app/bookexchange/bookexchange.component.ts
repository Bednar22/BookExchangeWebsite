import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { HttpClient } from '@angular/common/http';
import { BookexchangeService } from '../_services/bookexchange.service';
import { AlertifyService } from '../_services/alertify.service';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
@Component({
  selector: 'app-bookexchange',
  templateUrl: './bookexchange.component.html',
  styleUrls: ['./bookexchange.component.css'],
})
export class BookexchangeComponent implements OnInit {
  baseUrl = 'http://localhost:5000/api/usersbooks';

  bookexchangeForm: any;

  constructor(
    private formBuilder: FormBuilder,
    public bookexchangeService: BookexchangeService,
    private alertify: AlertifyService,
    public authService: AuthService
  ) {
    this.bookexchangeForm = this.formBuilder.group({
      bookTitle: new FormControl(),
      wantGet: new FormControl(),
      wantExchange: new FormControl(),
    });
  }
  model: any = {};

  ngOnInit() {}

  addExchange() {
    this.model.bookTitle = this.bookexchangeForm.value.bookTitle;
    this.model.Username = this.authService.decodedToken.unique_name;
    this.bookexchangeService.addExchange(this.model).subscribe(
      () => {
        this.alertify.success('successfully');
      },
      (error) => {
        this.alertify.error('failed');
      }
    );
    this.bookexchangeForm.reset();
  }

  changeStateExchange() {
    this.model.WantExchange = true;
    this.model.WantGet = false;
  }
  changeStateGet() {
    this.model.WantExchange = false;
    this.model.WantGet = true;
  }
  uncheckAll() {}
}
