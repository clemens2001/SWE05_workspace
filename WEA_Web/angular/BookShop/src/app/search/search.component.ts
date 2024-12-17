import { Component, EventEmitter, output, Output } from '@angular/core';
import { BookStoreService } from '../shared/book-store.service';
import { Book } from '../shared/book';
import { debounceTime, distinctUntilChanged, switchMap, tap } from 'rxjs';
import { NgClass } from '@angular/common';

@Component({
  selector: 'wea5-search',
  standalone: true,
  imports: [NgClass],
  templateUrl: './search.component.html',
  styles: ``
})
export class SearchComponent {

  constructor(private bs: BookStoreService) { }

  isLoading: boolean = false;
  foundBooks: Book[] = [];
  bookSelected = output<Book>();
  keyUp = new EventEmitter<string>();

  ngOnInit() {
    this.keyUp.pipe(
      debounceTime(500),
      distinctUntilChanged(),
      tap(() => this.isLoading = true),
      switchMap(searchTerm => this.bs.search(searchTerm)),
      tap(() => this.isLoading = false)
    ).subscribe(books => this.foundBooks = books);
  }

}
