import { Component, computed, EventEmitter, input, Input, OnInit, output, Output, signal } from '@angular/core';
import { Book } from '../shared/book';
import { CommonModule } from '@angular/common';
import { BookStoreService } from '../shared/book-store.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { environment } from '../../environments/environment';

@Component({
  selector: 'wea5-book-details',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './book-details.component.html',
  styles: ``
})
export class BookDetailsComponent implements OnInit {

  book = new Book();
  showListEvent = output();


  constructor(private bookStoreService: BookStoreService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private sanitizer: DomSanitizer
  ) { }

  imageUrl() {
      return this.sanitizer.bypassSecurityTrustResourceUrl(`${environment.images}/${this.book.picture}`)
  }

  ngOnInit(): void {
        //const params = this.route.snapshot.params;
    // this.book = this.bookStoreService.getBookById(params['id']);
    //this.bookStoreService.getBookById(params['id']).subscribe(book => this.book = book);
    
    this.activatedRoute.params.subscribe(params => {
      this.bookStoreService.getBookById(params['id']).subscribe(book => this.book = book);
    });
  }

  showBookList() {
    this.router.navigateByUrl('/books');
  }


}
