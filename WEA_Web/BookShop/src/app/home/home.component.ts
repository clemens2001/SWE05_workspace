import { Component } from '@angular/core';
import {RouterLink} from '@angular/router';

@Component({
  selector: 'wea5-home',
  standalone: true,
  imports: [
    RouterLink
  ],
  template: `
    <h1>Home</h1>
    <p>Willkommen im WEA5 BookShop.</p>
    <a routerLink="../books" class="ui red button">
      Buchliste ansehen
      <i class="right arrow icon"></i>
    </a>
  `,
  styles: ``
})
export class HomeComponent {

}
