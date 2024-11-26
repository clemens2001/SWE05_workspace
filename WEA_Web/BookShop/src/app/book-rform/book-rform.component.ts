import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { BookRFormErrorMessages } from './book-rform-error-messages';
import { Book } from '../shared/book';
import { isbnValidator } from '../shared/isbn-validator.directive';
import { ActivatedRoute, Router } from '@angular/router';
import { BookStoreService } from '../shared/book-store.service';

@Component({
  selector: 'wea5-book-rform',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './book-rform.component.html',
  styles: ``
})
export class BookRformComponent {

  isUpdatingBook = false;
  myForm!: FormGroup;
  book = new Book();
  errors: { [key: string]: string } = {};

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private bs: BookStoreService) { }

  ngOnInit() {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.isUpdatingBook = true;
      // TODO load book
    }
    this.initForm();
  }

  initForm() {

    this.myForm.statusChanges.subscribe(() => this.updateErrorMessages());
  }

  submitForm() {
    if (this.isUpdatingBook) {
      // TODO Update
    } else {
      // TODO Save
    }
  }

  updateErrorMessages() {
    this.errors = {};

    for (const message of BookRFormErrorMessages) {
      const control = this.myForm.get(message.forControl);
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
