package design.patterns.books;

import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class DaVinciCodeBook extends Book {

    public DaVinciCodeBook() {
        super(BookType.DA_VINCI_CODE, Binding.HARDBACK, 568, "Dan Brown", "Wydawnictwo Sonia Draga");
    }
}
