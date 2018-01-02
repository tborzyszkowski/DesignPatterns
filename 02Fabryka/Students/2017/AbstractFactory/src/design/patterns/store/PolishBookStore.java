package design.patterns.store;


import design.patterns.bookpartsfactory.BookPartsFactory;
import design.patterns.bookpartsfactory.PolishItBookPartsFactory;
import design.patterns.books.Book;
import design.patterns.books.enums.BookType;
import design.patterns.books.pl.PolishItBook;

public class PolishBookStore extends BookStore {

    @Override
    protected Book createBook(BookType bookType) {
        Book polishBook = null;
        BookPartsFactory partsFactory = new PolishItBookPartsFactory();
        switch (bookType) {
            case IT:
                polishBook = new PolishItBook(partsFactory);
                break;
        }

        return polishBook;
    }
}
