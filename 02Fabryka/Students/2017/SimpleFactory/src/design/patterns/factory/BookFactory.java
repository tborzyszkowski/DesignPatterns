package design.patterns.factory;

import design.patterns.books.*;
import design.patterns.books.enums.BookType;

public class BookFactory {

    public Book create(BookType bookType){
        Book book = null;

        switch(bookType){
            case IT:
                book = new ItBook();
                break;
            case HOBBIT:
                book = new HobbitBook();
                break;
            case DA_VINCI_CODE:
                book = new DaVinciCodeBook();
                break;
            case SONG_OF_ICE_AND_FIRE:
                book = new SongOfIceAndFireBook();
                break;
        }

        return book;
    }
}
