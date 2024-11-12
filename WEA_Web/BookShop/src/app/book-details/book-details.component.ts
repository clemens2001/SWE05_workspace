import { CommonModule } from '@angular/common';
import {Component, Input, OnInit, output} from '@angular/core';
import { Book } from '../shared/book';
import {BookStoreService} from '../shared/book-store.service';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'wea5-book-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './book-details.component.html',
  styles: ``
})
export class BookDetailsComponent implements OnInit{
  @Input() book: Book = new Book();
  // showListEvent = output();  // @Output / EventEmitter

  constructor(public bookStoreService: BookStoreService,
              private route: ActivatedRoute,
              private router: Router) {
  }

  ngOnInit() {
    const params = this.route.snapshot.params;
    // this.book = this.bookStoreService.getBookById(params['id']);
    this.bookStoreService.getBookById(params['id']).subscribe(book => this.book = book);
  }

  showBookList() {
    // this.showListEvent.emit();
    this.router.navigateByUrl('/books');
  }
}
