package builder_vs_factory;

public class LotRFactory extends FantasyFactory {

    private static LotRFactory instance;

    private LotRFactory() {
    }

    public static LotRFactory getInstance(){
        if(instance == null) {
            instance = new LotRFactory();
        }
        return instance;
    }

    @Override
    public Book createBook() {
        return new LotRBook();
    }

    @Override
    public Movie createMovie() {
        return new LotRMovie();
    }
}
