import { Component, input, Input } from '@angular/core';
import { Book } from '../shared/book';
import { DomSanitizer } from '@angular/platform-browser';
import { environment } from '../../environments/environment';

@Component({
  selector: 'a.wea5-book-list-item',
  standalone: true,
  imports: [],
  templateUrl: './book-list-item.component.html',
  styles: ``
})
export class BookListItemComponent {

  book = input.required<Book>();

  constructor(private sanitizer: DomSanitizer) { }

  imageUrl() {
      return this.sanitizer.bypassSecurityTrustResourceUrl(`${environment.images}/${this.book().picture}`)
  }

}
