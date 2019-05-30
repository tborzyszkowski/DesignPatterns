package abstrakcyjna;

public class Fantasy {

    private FantasyFactory fantasyFactory;

    public Fantasy(FantasyFactory fantasyFactory){
        this.fantasyFactory = fantasyFactory;
    }

    public Movie getMovie(){
        return fantasyFactory.createMovie();
    }

    public Book getBook(){
        return  fantasyFactory.createBook();
    }
}
