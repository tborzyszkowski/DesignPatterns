package mbreza.Wytworcza;

public class HorrorFactory extends BookFactory {

    private static HorrorFactory instance = null;

    private HorrorFactory() {
    }

    public static HorrorFactory createInstance() {
        if (instance == null) {
            instance = new HorrorFactory();
        }
        return instance;
    }

    @Override
    public Book createBook(BookType bookType) {
        switch (bookType) {
            case It:
                return new It();
            case SalemsLot:
                return new SalemsLot();
            default:
                return null;
        }
    }
}
