package mbreza.Wytworcza;

public class FantasyFactory extends BookFactory {

    private static FantasyFactory instance = null;

    private FantasyFactory() {
    }

    public static FantasyFactory createInstance() {
        if (instance == null) {
            instance = new FantasyFactory();
        }
        return instance;
    }

    @Override
    public Book createBook(BookType bookType) {
        switch (bookType) {
            case Witcher:
                return new Witcher();
            case GameOfThrones:
                return new GameOfThrones();
            default:
                return null;
        }
    }
}
