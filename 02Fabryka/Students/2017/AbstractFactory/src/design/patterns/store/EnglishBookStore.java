package design.patterns.store;

import design.patterns.books.Book;
import design.patterns.books.en.EnglishDaVinciCodeBook;
import design.patterns.books.en.EnglishHobbitBook;
import design.patterns.books.en.EnglishItBook;
import design.patterns.books.en.EnglishSongOfIceAndFireBook;
import design.patterns.books.enums.BookType;

public class EnglishBookStore extends BookStore {

    @Override
    protected Book createBook(BookType bookType) {
        Book englishBook = null;

        switch (bookType) {
            case IT:
                englishBook = new EnglishItBook();
                break;
            case DA_VINCI_CODE:
                englishBook = new EnglishDaVinciCodeBook();
                break;
            case HOBBIT:
                englishBook = new EnglishHobbitBook();
                break;
            case SONG_OF_ICE_AND_FIRE:
                englishBook = new EnglishSongOfIceAndFireBook();
                break;
        }

        return englishBook;
    }
}
