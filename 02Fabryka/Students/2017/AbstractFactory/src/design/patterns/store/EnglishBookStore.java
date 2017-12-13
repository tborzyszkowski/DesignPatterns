package design.patterns.store;

import design.patterns.bookpartsfactory.BookPartsFactory;
import design.patterns.bookpartsfactory.EnglishItBookPartsFactory;
import design.patterns.books.Book;
import design.patterns.books.en.EnglishItBook;
import design.patterns.books.enums.BookType;

public class EnglishBookStore extends BookStore {

    @Override
    protected Book createBook(BookType bookType) {
        Book englishBook = null;
        BookPartsFactory partsFactory = new EnglishItBookPartsFactory();
        switch (bookType) {
            case IT:
                englishBook = new EnglishItBook(partsFactory);
                break;
        }

        return englishBook;
    }
}
