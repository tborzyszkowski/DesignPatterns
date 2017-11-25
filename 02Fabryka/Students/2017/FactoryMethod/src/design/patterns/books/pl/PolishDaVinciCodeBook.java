package design.patterns.books.pl;

import design.patterns.books.Book;
import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class PolishDaVinciCodeBook extends Book {

    public PolishDaVinciCodeBook() {
        super(BookType.DA_VINCI_CODE, Binding.HARDBACK, 568, "Dan Brown", "Wydawnictwo Sonia Draga");
    }
}
