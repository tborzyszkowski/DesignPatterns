package design.patterns.store;


import design.patterns.books.Book;
import design.patterns.books.enums.BookType;
import design.patterns.books.pl.PolishDaVinciCodeBook;
import design.patterns.books.pl.PolishHobbitBook;
import design.patterns.books.pl.PolishItBook;
import design.patterns.books.pl.PolishSongOfIceAndFireBook;

public class PolishBookStore extends BookStore {

    @Override
    protected Book createBook(BookType bookType) {
        Book polishBook = null;

        switch (bookType) {
            case IT:
                polishBook = new PolishItBook();
                break;
            case DA_VINCI_CODE:
                polishBook = new PolishDaVinciCodeBook();
                break;
            case HOBBIT:
                polishBook = new PolishHobbitBook();
                break;
            case SONG_OF_ICE_AND_FIRE:
                polishBook = new PolishSongOfIceAndFireBook();
                break;
        }

        return polishBook;
    }
}
