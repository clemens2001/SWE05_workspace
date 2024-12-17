import { Component, EventEmitter, OnInit, output, Output } from '@angular/core';
import { Book } from '../shared/book';
import { CommonModule } from '@angular/common';
import { BookListItemComponent } from '../book-list-item/book-list-item.component';
import { BookStoreService } from '../shared/book-store.service';
import { RouterLink } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'wea5-book-list',
  standalone: true,
  imports: [BookListItemComponent, RouterLink],
  templateUrl: './book-list.component.html',
  styles: ``
})
export class BookListComponent implements OnInit {
  books: Book[] = [];

  sub?: Subscription;

  showDetailsEvent = output<Book>();

  constructor(private bookStoreService: BookStoreService) {}
  
  showDetails(book: Book) {
    this.showDetailsEvent.emit(book);
  }

  ngOnInit(): void {
    //this.books = this.bookStoreService.getAll();
    this.sub = this.bookStoreService.getAll().subscribe(books => this.books = books);
  }

  ngOnDestroy() : void {
    if(this.sub) {
      this.sub.unsubscribe();
    }
  }

}
