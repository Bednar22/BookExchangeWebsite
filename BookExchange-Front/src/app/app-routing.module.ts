import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BooksearchComponent } from './booksearch/booksearch.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: 'booksearch', component: BooksearchComponent },
  { path: '', component: HomeComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
