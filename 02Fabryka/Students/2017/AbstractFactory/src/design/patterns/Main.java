package design.patterns;

import design.patterns.books.Book;
import design.patterns.books.enums.BookType;
import design.patterns.store.BookStore;
import design.patterns.store.EnglishBookStore;
import design.patterns.store.PolishBookStore;

public class Main {

    public static void main(String[] args) {
        BookStore polishBookStore = new PolishBookStore();
        BookStore englishBookStore = new EnglishBookStore();

        Book polishItBook = polishBookStore.order(BookType.IT);
        System.out.println(polishItBook.toString());

        Book englishItBook = englishBookStore.order(BookType.IT);
        System.out.println(englishItBook.toString());
    }
}
