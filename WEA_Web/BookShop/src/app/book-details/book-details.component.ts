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

  book = signal(new Book);  //new Book();
  shoppingCart = signal<Array<Book>>([]);
  totalPrice = computed(() => {
    let sum = 0.0;
    for (const book of this.shoppingCart()) {
      if(book.price) {
        sum += Number(book.price);
      }
    }
    return sum;
  });
  showListEvent = output();


  constructor(private bookStoreService: BookStoreService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private sanitizer: DomSanitizer
  ) { }

  imageUrl() {
      return this.sanitizer.bypassSecurityTrustResourceUrl(`${environment.images}/${this.book().picture}`)
  }

  ngOnInit(): void {
        //const params = this.route.snapshot.params;
    // this.book = this.bookStoreService.getBookById(params['id']);
    //this.bookStoreService.getBookById(params['id']).subscribe(book => this.book = book);

    this.activatedRoute.params.subscribe(params => {
      this.bookStoreService.getBookById(params['id']).subscribe(book => this.book.set(book));
    });
  }

  showBookList() {
    this.router.navigateByUrl('/books');
  }

  addToShoppingCart() {
    const data = localStorage.getItem('WEA5.shoppingCart') || '[]';
    const item = JSON.parse(data);
    item.push(this.book().id);
    this.shoppingCart.set([this.book(), ...this.shoppingCart()]);
    localStorage.setItem('WEA5.shoppingCart', JSON.stringify(item));
  }

}
