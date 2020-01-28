import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Book, BookType } from '../app/models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {
    private bookUrl;

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.bookUrl  = baseUrl + '/api/book/';  // URL to web api
    }

    getBooks(): Observable<Book[]> {
        return this.http.get<Book[]>(this.bookUrl);
    }

    getBookById(id: string): Observable<Book> {
        return this.http.get<Book>(this.bookUrl + id);
    }

    removeBook(id: string): Observable<Book> {
        return this.http.delete<Book>(this.bookUrl + id);
    }

    addBook(book: Book): Observable<Book> {
        return this.http.post<Book>(this.bookUrl, book);
    }

    updateBook(book: Book): Observable<Book> {
        return this.http.put<Book>(this.bookUrl + book.Id, book);
    }
}
