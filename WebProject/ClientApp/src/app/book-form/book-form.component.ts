import { Component, OnInit } from '@angular/core';
import { Book } from '../models/book';
import { Router, ActivatedRoute, Params } from "@angular/router";
import { BookService } from '../book.service';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

    book: Book;
    id: string;
    edit: boolean;

    constructor(private router: Router, private route: ActivatedRoute, private bookService: BookService) { }

    ngOnInit() {
        this.route.params.subscribe((params: Params) => {
            this.id = params['id'];

        })

        if (this.id) {
            this.bookService.getBookById(this.id).subscribe(x => this.book = x);
            this.edit = true;
        } else {
            this.book = new Book();
            this.edit = false;
        }
    }
        

    addBook() {
        this.bookService.addBook(this.book)
            .subscribe(data => {
                this.router.navigate(['books-list']);
            });
    }

    editBook() {
        this.bookService.updateBook(this.book)
            .subscribe(data => {
                this.router.navigate(['books-list']);
            });
    }

}
