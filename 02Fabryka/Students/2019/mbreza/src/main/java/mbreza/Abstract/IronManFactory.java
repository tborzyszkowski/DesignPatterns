package mbreza.Abstract;

public class IronManFactory extends PopCultureFactory{

    private static IronManFactory instance = null;

    private IronManFactory() {
    }

    public static IronManFactory createInstance(){
        if(instance == null) {
            instance = new IronManFactory();
        }
        return instance;
    }

    @Override
    public Comic createComic() {
        return new IronManComic();
    }

    @Override
    public Movie createMovie() {
        return new IronManMovie();
    }
}
