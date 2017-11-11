package design.patterns.books.en;

import design.patterns.bookpartsfactory.BookPartsFactory;
import design.patterns.books.Book;
import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class EnglishItBook extends Book {

    private BookPartsFactory bookPartsFactory;

    public EnglishItBook(BookPartsFactory bookPartsFactory) {
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
