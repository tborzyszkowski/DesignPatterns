package design.patterns;

import design.patterns.books.Book;
import design.patterns.books.enums.BookType;
import design.patterns.factory.BookFactory;
import design.patterns.store.BookStore;

public class Main {

    public static void main(String[] args) {
        BookFactory factory =  new BookFactory();
        BookStore store = new BookStore(factory);

        Book itBook = store.order(BookType.IT);
        System.out.println(itBook.toString());

        Book daVinciCode = store.order(BookType.DA_VINCI_CODE);
        System.out.println(daVinciCode.toString());

        Book hobbit = store.order(BookType.HOBBIT);
        System.out.println(hobbit.toString());

        Book songOfIceAndFire = store.order(BookType.SONG_OF_ICE_AND_FIRE);
        System.out.println(songOfIceAndFire.toString());
    }
}
