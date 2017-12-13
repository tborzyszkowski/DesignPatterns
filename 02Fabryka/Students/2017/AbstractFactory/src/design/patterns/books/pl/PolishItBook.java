package design.patterns.books.pl;

import design.patterns.bookpartsfactory.BookPartsFactory;
import design.patterns.books.Book;
import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class PolishItBook extends Book {

    private BookPartsFactory bookPartsFactory;

    public PolishItBook(BookPartsFactory bookPartsFactory) {
        this.bookPartsFactory = bookPartsFactory;
        bookType = BookType.IT;
    }

    @Override
    public void prepare() {
        author = bookPartsFactory.getAuthor();
        publisher = bookPartsFactory.getPublisher();
        pages = bookPartsFactory.pageCount();
    }
}
