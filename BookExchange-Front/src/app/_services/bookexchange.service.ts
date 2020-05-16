import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class BookexchangeService {
  baseUrl = 'http://localhost:5000/api/usersbooks';
  constructor(private http: HttpClient, public authService: AuthService) {}

  addExchange(model: any) {
    console.log(model);
    return this.http.post(this.baseUrl, model);
  }
}
