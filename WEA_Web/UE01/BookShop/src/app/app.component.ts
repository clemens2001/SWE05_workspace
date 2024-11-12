import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { BookListComponent } from "./book-list/book-list.component";

@Component({
  selector: 'wea5-root',
  standalone: true,
  imports: [RouterOutlet, BookListComponent],
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  title = 'BookShop';
}
