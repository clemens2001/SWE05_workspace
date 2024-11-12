import { CommonModule } from '@angular/common';
import {Component, Input, output} from '@angular/core';
import { Book } from '../shared/book';

@Component({
  selector: 'wea5-book-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './book-details.component.html',
  styles: ``
})
export class BookDetailsComponent {
  @Input() book: Book = new Book();

  showListEvent = output();  // @Output / EventEmitter
  showBookList() {
    this.showListEvent.emit();
  }
}
