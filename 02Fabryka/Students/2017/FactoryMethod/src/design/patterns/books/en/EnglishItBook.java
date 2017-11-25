package design.patterns.books.en;

import design.patterns.books.Book;
import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class EnglishItBook extends Book {

    public EnglishItBook() {
        super(BookType.IT, Binding.SOFT_BINDING, 1104, "Stephen King", "Scribner");
    }
}
