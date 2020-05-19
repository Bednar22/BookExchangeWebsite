import { Component, OnInit } from '@angular/core';
import { BookexchangeService } from '../_services/bookexchange.service';
import { BookexchangeComponent } from '../bookexchange/bookexchange.component';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-exchangeslist',
  templateUrl: './exchangeslist.component.html',
  styleUrls: ['./exchangeslist.component.css'],
})
export class ExchangeslistComponent implements OnInit {
  constructor(private http: HttpClient) {}
  exchangelist: any;
  baseUrl = 'http://localhost:5000/api/usersbooks';

  ngOnInit() {
    this.getExchangeList();
  }

  getExchangeList() {
    this.http.get(this.baseUrl).subscribe(
      (response) => {
        this.exchangelist = response;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
