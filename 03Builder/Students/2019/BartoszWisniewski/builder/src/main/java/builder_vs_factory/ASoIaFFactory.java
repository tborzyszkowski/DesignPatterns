package builder_vs_factory;

public class ASoIaFFactory extends FantasyFactory{

    private static ASoIaFFactory instance;

    private ASoIaFFactory() {
    }

    public static ASoIaFFactory getInstance(){
        if(instance == null) {
            instance = new ASoIaFFactory();
        }
        return instance;
    }

    @Override
    public Book createBook() {
        return new ASoIaFBook();
    }

    @Override
    public Movie createMovie() {
        return new ASoIaFMovie();
    }
}
