import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Book } from '../shared/book';
import { BookListItemComponent } from '../book-list-item/book-list-item.component';
import {BookStoreService} from '../shared/book-store.service';
import {RouterLink} from '@angular/router';

@Component({
  selector: 'wea5-book-list',
  standalone: true,
  imports: [BookListItemComponent, RouterLink],
  templateUrl: './book-list.component.html',
  styles: ``
})
export class BookListComponent implements OnInit {

  books: Book[] = [];

  @Output() showDetailsEvent = new EventEmitter<Book>();

  constructor(public bookStoreService: BookStoreService) {
  }

  showDetails(book: Book) {
    this.showDetailsEvent.emit(book);
  }

  ngOnInit(): void {
    this.books = this.bookStoreService.getAll();
  }

}
