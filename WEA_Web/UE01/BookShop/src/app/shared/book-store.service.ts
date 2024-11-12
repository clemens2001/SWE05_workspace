import { Injectable } from '@angular/core';
import {Book} from './book';

@Injectable({
  providedIn: 'root'
})
export class BookStoreService {

  books: Book[] = [];
  constructor() {

  }
}
