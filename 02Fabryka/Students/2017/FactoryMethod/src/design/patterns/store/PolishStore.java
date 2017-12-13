package design.patterns.store;

import design.patterns.books.Book;
import design.patterns.books.enums.BookType;
import design.patterns.books.pl.PolishDaVinciCodeBook;
import design.patterns.books.pl.PolishHobbitBook;
import design.patterns.books.pl.PolishItBook;
import design.patterns.books.pl.PolishSongOfIceAndFireBook;

public class PolishStore extends BookStore {

    @Override
    protected Book createBook(BookType bookType) {
        Book book = null;

        switch (bookType) {
            case IT:
                book = new PolishItBook();
                break;
            case HOBBIT:
                book = new PolishHobbitBook();
                break;
            case DA_VINCI_CODE:
                book = new PolishDaVinciCodeBook();
                break;
            case SONG_OF_ICE_AND_FIRE:
                book = new PolishSongOfIceAndFireBook();
                break;
        }
        return book;
    }
}
