import { Injectable } from '@angular/core';
import { Book } from './book';
import { HttpClient } from '@angular/common/http';
import { catchError, map, Observable, of, retry } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookStoreService {

  private books: Book[] = [];

  constructor(private http: HttpClient) { }

  private errorHandler(error: Error | any): Observable<any> {
    console.log(error);
    return of(null);
  }

  getAll(): Observable<Book[]> {
    return this.http.get<Book[]>(`${environment.server}/books`)
      .pipe(map<any, Book[]>(res => res['books']), catchError(this.errorHandler));
  }

  getBookById(id: string): Observable<Book> {
    return this.http.get<Book>(`${environment.server}/book/${id}`)
      .pipe(map<any, Book[]>(res => res.book), catchError(this.errorHandler));
  }

  save(book: Book): Observable<any> {
    return this.http.post(`${environment.server}/save`, book)
      .pipe(catchError(this.errorHandler));
  }

  update(book: Book): Observable<any> {
    return this.http.put(`${environment.server}/update/${book.isbn}`, book)
      .pipe(catchError(this.errorHandler));
  }

}
