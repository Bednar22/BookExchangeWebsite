import { Component, OnInit } from '@angular/core';
import { SearchService } from '../_services/search.service';
import { Router } from '@angular/router';
import {
  FormControl,
  FormGroup,
  Validators,
  FormBuilder,
} from '@angular/forms';
import {
  debounceTime,
  map,
  distinctUntilChanged,
  filter,
  switchMap,
} from 'rxjs/operators';
@Component({
  selector: 'app-booksearch',
  templateUrl: './booksearch.component.html',
  styleUrls: ['./booksearch.component.css'],
})
export class BooksearchComponent implements OnInit {
  items: any;
  loading;
  queryField: FormControl = new FormControl();
  constructor(
    private searchService: SearchService,
    private formBuilder: FormBuilder,
    private router: Router
  ) {}

  ngOnInit() {
    this.loading = false;
    this.queryField.valueChanges
      .pipe(debounceTime(1000), distinctUntilChanged())
      .subscribe((queryField: any) => {
        let te = queryField.replace(/\s/g, '');
        if (te.length > 2) {
          this.searchService.get(queryField).subscribe((result: any) => {
            this.loading = true;
            setTimeout(() => {
              this.items = result.items;
            }, 2000);
          });
        }
      });
  }
  combineSlug(id) {
    return `${id}`;
  }
  goToLink(url: string) {
    window.open(url, '_blank');
  }
}
