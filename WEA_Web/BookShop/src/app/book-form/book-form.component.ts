import { Component, ViewChild } from '@angular/core';
import { Book } from '../shared/book';
import { BookFormErrorMessages } from './book-form-error-messages';
import { BookStoreService } from '../shared/book-store.service';
import { NgForm, FormsModule } from '@angular/forms';
import { DateValueAccessor } from 'angular-date-value-accessor';
import { IsbnValidatorDirective } from '../shared/isbn-validator.directive';

@Component({
  selector: 'wea5-book-form',
  standalone: true,
  imports: [FormsModule, DateValueAccessor, IsbnValidatorDirective],
  templateUrl: './book-form.component.html',
  styles: ``
})
export class BookFormComponent {

  @ViewChild('myForm', {static: true}) myForm!: NgForm;
  book = new Book();
  errors: { [key: string]: string } = {};

  constructor(private bs: BookStoreService) { }

  ngOnInit() {
    this.myForm.statusChanges?.subscribe(() => this.updateErrorMessages());
  }

  submitForm() {

  } 

  updateErrorMessages() {
      this.errors = {};
      for (const message of BookFormErrorMessages) {
          const control = this.myForm.form.get(message.forControl) || {dirty: false, invalid: false, errors: []};

          if (control &&
              control.dirty &&
              control.invalid &&
              control.errors != null &&
              control.errors[message.forValidator] &&
              !this.errors[message.forControl]) {
              this.errors[message.forControl] = message.text;
          }
      }
  }

}
