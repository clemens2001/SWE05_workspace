import { Component } from '@angular/core';
import {RouterLink, RouterLinkActive, RouterOutlet} from '@angular/router';
import { BookListComponent } from "./book-list/book-list.component";
import { Book } from './shared/book';
import { BookDetailsComponent } from "./book-details/book-details.component";

@Component({
  selector: 'wea5-root',
  standalone: true,
  imports: [RouterOutlet, BookListComponent, BookDetailsComponent, RouterLink, RouterLinkActive],
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  listOn = true;
  detailsOn = false;
  book: Book = new Book();

  showDetails(book: Book) {
    this.book = book;
    this.listOn = false;
    this.detailsOn = true;
  }

  showList() {
    this.listOn = true;
    this.detailsOn = false;
  }
}
