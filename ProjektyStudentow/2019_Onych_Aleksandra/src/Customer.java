public class Customer implements Observer {
    private String name;
    private int rentedMovies = 0;
    private MovieRentalSubject movieRentalSubject;
    private Movie lastMovie;

    private static final String message = "Hi %s, added movie: %s";

    public Customer(String name, MovieRentalSubject movieRentalSubjecte) {
        this.name = name;
        this.movieRentalSubject = movieRentalSubjecte;
    }

    public Customer(String name, int rentedMovies) {
        this.name = name;
        this.rentedMovies = rentedMovies;
    }

    public int getRentedMovies() {
        return rentedMovies;
    }

    @Override
    public void update() {
        lastMovie = movieRentalSubject.getMovie();
        System.out.println(String.format(message, name, lastMovie.getTitle()));
    }
}
