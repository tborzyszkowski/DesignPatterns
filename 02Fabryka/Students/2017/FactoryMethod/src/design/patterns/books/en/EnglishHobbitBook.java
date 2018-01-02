package design.patterns.books.en;

import design.patterns.books.Book;
import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class EnglishHobbitBook extends Book {

    public EnglishHobbitBook() {
        super(BookType.HOBBIT, Binding.HARDBACK, 280, "John Ronald Tolkien", "Houghton Mifflin Harcourt");
    }
}
