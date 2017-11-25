package design.patterns.books.pl;

import design.patterns.books.Book;
import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class PolishSongOfIceAndFireBook extends Book {

    public PolishSongOfIceAndFireBook() {
        super(BookType.SONG_OF_ICE_AND_FIRE, Binding.SOFT_BINDING, 480, "George R. R. Martin", "Wydawnictwo Zysk i S-ka");
    }
}
