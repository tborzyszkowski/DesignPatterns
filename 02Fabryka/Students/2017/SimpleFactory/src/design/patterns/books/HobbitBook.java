package design.patterns.books;

import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class HobbitBook extends Book {

    public HobbitBook() {
        super(BookType.HOBBIT, Binding.HARDBACK, 280, "John Ronald Tolkien", "Wydawnictwo Iskry");
    }
}
