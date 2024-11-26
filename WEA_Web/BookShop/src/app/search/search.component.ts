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
  
  ngOnInit() {

  }

}
