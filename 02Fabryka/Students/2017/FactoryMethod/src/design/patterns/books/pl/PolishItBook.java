package design.patterns.books.pl;

import design.patterns.books.Book;
import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class PolishItBook extends Book {

    public PolishItBook() {
        super(BookType.IT, Binding.SOFT_BINDING, 1104, "Stephen King", "Wydawca Albatros");
    }
}
