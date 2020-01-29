import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book';
import { Router, ActivatedRoute, Params } from "@angular/router";
import { BookService } from '../book.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

    book: Book;
    id: string;
    edit: boolean;
    bookForm: FormGroup;
    submitted = false;
    addFailed = false;
    error = '';

    constructor(private router: Router, private route: ActivatedRoute, private bookService: BookService, private formBuilder: FormBuilder) { }

    ngOnInit() {
        this.route.params.subscribe((params: Params) => {
            this.id = params['id'];
        })

        if (this.id) {
            this.bookService.getBookById(this.id).subscribe(x => {
                this.book = x;
                this.setValues();
            });
            this.edit = true;
        } else {
            this.book = new Book();
            this.edit = false;
        }

        this.bookForm = this.formBuilder.group({
            title: ['', [Validators.required, Validators.maxLength(100)]],
            author: ['', [Validators.required, Validators.maxLength(40)]],
            descrtiption: ['', [Validators.required, Validators.maxLength(150)]],
            bookType: ['', Validators.required]
        });
    }

    get f() { return this.bookForm.controls; }

    onSubmit() {
        this.submitted = true;

        if (this.bookForm.invalid) {
            return;
        }

        if (this.edit) {
            this.editBook();
        }
        else {
            this.addBook();
        }
    }

    setValues() {
        this.bookForm.patchValue({
            author: this.book.Author,
            title: this.book.Title,
            descrtiption: this.book.Descrtiption,
            bookType: this.book.BookType
        });
    }

    addBook() {
        this.addFailed = false;
        this.error = '';
        this.book = this.bookForm.value;
        this.bookService.addBook(this.book)
            .subscribe(data => {
                this.router.navigate(['books-list']);
            },
                error => {
                    this.addFailed = true;
                    this.error = error['error'];
                });
    }

    editBook() {
        this.addFailed = false;
        this.error = '';
        this.book = this.bookForm.value;
        this.book.Id = this.id;
        this.bookService.updateBook(this.book)
            .subscribe(data => {
                this.router.navigate(['books-list']);
            },
                error => {
                    this.addFailed = true;
                    this.error = error['error'];
                });
    }

}
