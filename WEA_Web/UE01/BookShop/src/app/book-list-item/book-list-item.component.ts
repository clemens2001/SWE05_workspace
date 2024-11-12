import { Component, Input, input } from '@angular/core';
import { Book } from '../shared/book';

@Component({
  selector: 'a.wea5-book-list-item',
  standalone: true,
  imports: [],
  templateUrl: './book-list-item.component.html',
  styles: ``
})
export class BookListItemComponent {
  //@Input() book: Book = new Book();
  book = input.required<Book>();

}
