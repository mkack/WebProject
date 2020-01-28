export class Book {
    Id: string;
    Title: string;
    Author: string;
    Descrtiption: string;
    BookType: BookType;
}

export enum BookType {
    Crime,
    Fantasy,
    Horror,
    Humor,
    Drama
}