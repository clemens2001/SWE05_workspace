import { Component, EventEmitter, OnInit, output, Output } from '@angular/core';
import { Book } from '../shared/book';
import { CommonModule } from '@angular/common';
import { BookListItemComponent } from '../book-list-item/book-list-item.component';
import { BookStoreService } from '../shared/book-store.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'wea5-book-list',
  standalone: true,
  imports: [BookListItemComponent, RouterLink],
  templateUrl: './book-list.component.html',
  styles: ``
})
export class BookListComponent implements OnInit {
  books: Book[] = [];

  showDetailsEvent = output<Book>();

  constructor(private bookStoreService: BookStoreService) {}

  ngOnInit(): void {
    this.bookStoreService.getAll().subscribe({next: res => {
      this.books = res;
    }});
  }

  showDetails(book: Book) {
    this.showDetailsEvent.emit(book);
  }

}
