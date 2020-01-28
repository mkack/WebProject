import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { BookService } from '../book.service';
import { Book, BookType } from '../models/book';


@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.css']
})
export class BooksListComponent implements OnInit {
    books: Book[];
    BookType: typeof
        BookType = BookType;

    constructor(private router: Router, private bookService: BookService) { }

    ngOnInit() {
        this.getBooks();
  }

    getBooks(): void {
        this.bookService.getBooks().subscribe(x => {
            this.books = x;
        });
    }

    removeBook(book: Book): void {
        this.bookService.removeBook(book.Id)
            .subscribe(x => {
                this.books = this.books.filter(b => b !== book);
            })
    };

    addBook(): void {
        this.router.navigate(['book-form']);
    };

    updateBook(id: string): void {
        this.router.navigate(['book-form/' + id]);
    }
}
