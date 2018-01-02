package design.patterns.books.en;

import design.patterns.books.Book;
import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class EnglishDaVinciCodeBook extends Book {

    public EnglishDaVinciCodeBook() {
        super(BookType.DA_VINCI_CODE, Binding.HARDBACK, 568, "Dan Brown", "Anchor");
    }
}
