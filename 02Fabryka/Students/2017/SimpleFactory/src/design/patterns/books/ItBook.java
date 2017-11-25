package design.patterns.books;

import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class ItBook extends Book {

    public ItBook() {
        super(BookType.IT, Binding.SOFT_BINDING, 1104, "Stephen King", "Wydawca Albatros");
    }
}
