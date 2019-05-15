package decorator;

public abstract class AbstractMovieDecorator extends AbstractMovie {
    protected AbstractMovie movie;

    public AbstractMovieDecorator(AbstractMovie movie) {
        this.movie = movie;
    }
}
