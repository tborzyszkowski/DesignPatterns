package design.patterns.books;

import design.patterns.books.enums.Binding;
import design.patterns.books.enums.BookType;

public class SongOfIceAndFireBook extends Book {

    public SongOfIceAndFireBook() {
        super(BookType.SONG_OF_ICE_AND_FIRE, Binding.SOFT_BINDING, 480, "George R. R. Martin", "Wydawnictwo Zysk i S-ka");
    }
}
