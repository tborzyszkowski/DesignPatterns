package design.patterns.store;

import design.patterns.books.Book;
import design.patterns.books.enums.BookType;
import design.patterns.factory.BookFactory;

public class BookStore {

    private BookFactory factory;

    public BookStore(BookFactory factory) {
        this.factory = factory;
    }

    public Book order(BookType bookType){
        Book book = factory.create(bookType);
        book.collecting();
        book.packing();
        book.send();
        return book;
    }
}
