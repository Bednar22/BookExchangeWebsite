import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BooksearchComponent } from './booksearch/booksearch.component';
import { HomeComponent } from './home/home.component';
import { BookexchangeComponent } from './bookexchange/bookexchange.component';

const routes: Routes = [
  { path: 'booksearch', component: BooksearchComponent },
  { path: '', component: HomeComponent },
  { path: 'bookexchange', component: BookexchangeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
