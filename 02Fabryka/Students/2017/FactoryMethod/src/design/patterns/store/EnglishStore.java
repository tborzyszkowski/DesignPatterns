package design.patterns.store;

import design.patterns.books.Book;
import design.patterns.books.en.EnglishDaVinciCodeBook;
import design.patterns.books.en.EnglishHobbitBook;
import design.patterns.books.en.EnglishItBook;
import design.patterns.books.en.EnglishSongOfIceAndFireBook;
import design.patterns.books.enums.BookType;

public class EnglishStore extends BookStore {

    @Override
    protected Book createBook(BookType bookType) {
        Book book = null;

        switch (bookType) {
            case IT:
                book = new EnglishItBook();
                break;
            case HOBBIT:
                book = new EnglishHobbitBook();
                break;
            case DA_VINCI_CODE:
                book = new EnglishDaVinciCodeBook();
                break;
            case SONG_OF_ICE_AND_FIRE:
                book = new EnglishSongOfIceAndFireBook();
                break;
        }
        return book;
    }
}
