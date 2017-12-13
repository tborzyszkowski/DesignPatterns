package design.patterns.books.en;

import design.patterns.books.Book;
import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class EnglishSongOfIceAndFireBook extends Book {

    public EnglishSongOfIceAndFireBook() {
        super(BookType.SONG_OF_ICE_AND_FIRE, Binding.SOFT_BINDING, 480, "George R. R. Martin", "Bantam");
    }
}
