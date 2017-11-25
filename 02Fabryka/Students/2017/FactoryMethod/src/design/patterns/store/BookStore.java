package design.patterns.store;

import design.patterns.books.Book;
import design.patterns.books.enums.BookType;

public abstract class BookStore {

    public Book order(BookType bookType) {
        Book book = createBook(bookType);
        book.collecting();
        book.packing();
        book.send();

        return book;
    }

    protected abstract Book createBook(BookType bookType);
}
