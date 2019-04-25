package mbreza.Abstract;

public class BatmanFactory extends PopCultureFactory {

    private static BatmanFactory instance = null;

    private BatmanFactory() {
    }

    public static BatmanFactory createInstance(){
        if(instance == null) {
            instance = new BatmanFactory();
        }
        return instance;
    }

    @Override
    public Comic createComic() {
        return new BatmanComic();
    }

    @Override
    public Movie createMovie() {
        return new BatmanMovie();
    }
}
