import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { BookListComponent } from "./book-list/book-list.component";
import { Book } from './shared/book';
import { CommonModule } from '@angular/common';
import { BookDetailsComponent } from "./book-details/book-details.component";
import { authConfig } from './auth.config';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'wea5-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink, RouterLinkActive, BookListComponent, CommonModule, BookDetailsComponent],
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  title = 'BookShop';
  
  listOn = true;
  detailsOn = false;
  book: Book = new Book();
  
  showList() {
    this.listOn = true;
    this.detailsOn = false;
  }
  
  showDetails(book: Book) {
    this.book = book;
    this.listOn = false;
    this.detailsOn = true;
  }

  constructor(private oauthService: OAuthService) {
    // this.configureWithNewConfigApi();
  }

  private configureWithNewConfigApi() {
    this.oauthService.configure(authConfig);
    this.oauthService.loadDiscoveryDocumentAndTryLogin();
  }

}
