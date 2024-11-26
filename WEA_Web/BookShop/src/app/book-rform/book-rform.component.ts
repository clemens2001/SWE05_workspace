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
      this.bs.getBookById(id).subscribe(book => {
        this.book = book;
        this.initForm();
      });
    }
    this.initForm();
  }

  initForm() {
    this.myForm = this.fb.group({
      title: [this.book.title, Validators.required],
      id: this.book.id,
      isbn: [this.book.isbn, isbnValidator],
      description: this.book.description,
      author: this.book.author,
      year: this.book.year,
      price: this.book.price,
      picture: this.book.picture,
    });

    this.myForm.statusChanges.subscribe(() => this.updateErrorMessages());
  }

  submitForm() {
    const book = this.myForm.value;
    if (this.isUpdatingBook) {
      this.bs.update(book).subscribe(res => {
        this.router.navigate(['../../books', book.id], { relativeTo: this.route });
      });
    } else {
      this.bs.save(book).subscribe(res => {
        this.book = new Book();
        this.myForm.reset(this.book);
      });
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
