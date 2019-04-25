package mbreza.Abstract;

public class PopCulture {

    private PopCultureFactory popCultureFactory;

    public PopCulture(PopCultureFactory popCultureFactory){
        this.popCultureFactory = popCultureFactory;
    }

    public Movie getMovie(){
        return popCultureFactory.createMovie();
    }

    public Comic getComic(){
        return  popCultureFactory.createComic();
    }
}
