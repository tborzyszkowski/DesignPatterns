package design.patterns.books.pl;

import design.patterns.books.Book;
import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class PolishHobbitBook extends Book {

    public PolishHobbitBook() {
        super(BookType.HOBBIT, Binding.HARDBACK, 280, "John Ronald Tolkien", "Wydawnictwo Iskry");
    }
}
