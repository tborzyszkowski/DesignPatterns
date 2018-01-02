package design.patterns;

import design.patterns.books.Book;
import design.patterns.books.enums.BookType;
import design.patterns.store.BookStore;
import design.patterns.store.EnglishStore;
import design.patterns.store.PolishStore;

public class Main {

    public static void main(String[] args) {

        BookStore polishBookStore = new PolishStore();
        BookStore englishBookStore = new EnglishStore();

        Book polishItBook = polishBookStore.order(BookType.IT);
        System.out.println(polishItBook.toString());

        Book polishDaVinciCode = polishBookStore.order(BookType.DA_VINCI_CODE);
        System.out.println(polishDaVinciCode.toString());

        Book polishHobbit = polishBookStore.order(BookType.HOBBIT);
        System.out.println(polishHobbit.toString());

        Book polishSongOfIceAndFire = polishBookStore.order(BookType.SONG_OF_ICE_AND_FIRE);
        System.out.println(polishSongOfIceAndFire.toString());

        Book englishItBook = englishBookStore.order(BookType.IT);
        System.out.println(englishItBook.toString());

        Book englishDaVinciCode = englishBookStore.order(BookType.DA_VINCI_CODE);
        System.out.println(englishDaVinciCode.toString());

        Book englishHobbit = englishBookStore.order(BookType.HOBBIT);
        System.out.println(englishHobbit.toString());

        Book englishSongOfIceAndFire = englishBookStore.order(BookType.SONG_OF_ICE_AND_FIRE);
        System.out.println(englishSongOfIceAndFire.toString());
    }
}
