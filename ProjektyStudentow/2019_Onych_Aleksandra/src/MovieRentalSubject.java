import java.util.ArrayList;
import java.util.List;

public class MovieRentalSubject implements Subject {

    private List<Observer> movieRentalSubscribes = new ArrayList<>();
    private Movie movie;

    public void registerObserver(Observer observer) {
        movieRentalSubscribes.add(observer);
    }

    public void unregisterObserver(Observer observer) {
        movieRentalSubscribes.remove(observer);
    }

    public void notifyObservers() {
        movieRentalSubscribes.forEach(Observer::update);
    }

    public Movie getMovie() {
        return movie;
    }

    public void setMovie(Movie movie) {
        this.movie = movie;
    }

}
