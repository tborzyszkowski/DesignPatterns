import decorator.AbstractMovie;
import decorator.RebateDecorator;
import enums.MovieMark;
import enums.MovieType;
import org.junit.jupiter.api.Test;

import java.util.Arrays;

import static org.junit.jupiter.api.Assertions.*;

class MovieRentalTest {

    MovieManager movieManager = new MovieManager();
    RentFacade rentFacade = new RentFacade();
    MovieVisitor visitor = new MovieVisitorImpl();
    MovieRentalSubject movieRental = new MovieRentalSubject();

    Movie johnWick = movieManager.getMoviePrototype("John Wick");
    Movie dirtyDancing = movieManager.getMoviePrototype("Dirty Dancing");
    Movie shrek = movieManager.getMoviePrototype("Shrek");

    @Test
    public void builderTest() {
        assertEquals(dirtyDancing.title, "Dirty Dancing");
        assertEquals(dirtyDancing.productionYear, "1987");
        assertEquals(dirtyDancing.type, MovieType.ROMANCE);
        assertEquals(dirtyDancing.isDamaged(), false);
        assertEquals(dirtyDancing.isRented(), true);
        assertEquals(dirtyDancing.getPrice(), 10.5);
        assertEquals(dirtyDancing.getMarks(), Arrays.asList(MovieMark.NUDITY));

        System.out.println(dirtyDancing);

    }

    @Test
    public void prototypeTest() {
        Movie dirtyDancing_2 = movieManager.getMoviePrototype("Dirty Dancing");

        assertNotSame(dirtyDancing, dirtyDancing_2);

        dirtyDancing_2.setRented(false);

        System.out.println(dirtyDancing);
        System.out.println(dirtyDancing_2);
    }

    @Test
    public void facadeTest() {
        Customer customer1 = new Customer("Peter", 1);
        Customer customer2 = new Customer("James", 3);

        assertEquals(johnWick.isRented(), false);
        assertEquals(johnWick.isDamaged(), false);

        assertEquals(dirtyDancing.isRented(), true);
        assertEquals(dirtyDancing.isDamaged(), false);

        assertEquals(shrek.isRented(), false);
        assertEquals(shrek.isDamaged(), true);


        assertEquals(true, rentFacade.isRentPossible(customer1, johnWick));
        assertEquals(false, rentFacade.isRentPossible(customer1, dirtyDancing));
        assertEquals(false, rentFacade.isRentPossible(customer1, shrek));
        assertEquals(false, rentFacade.isRentPossible(customer2, johnWick));
    }

    @Test
    public void decoratorTest() {
        AbstractMovie johnWickRebate = new RebateDecorator(10, johnWick);

        assertNotEquals(johnWickRebate.getPrice(), johnWick.getPrice());

        System.out.println(johnWick.getPrice());
        System.out.println(johnWickRebate.getPrice());

    }

    @Test
    public void visitorTest() {
        String movieInfo = "Title: %s, marks: %s, ageGroup: %s";

        System.out.println(String.format(movieInfo, johnWick.getTitle(), johnWick.getMarks(), johnWick.getAgeGroup()));
        System.out.println(String.format(movieInfo, shrek.getTitle(), shrek.getMarks(), shrek.getAgeGroup()));
        System.out.println(String.format(movieInfo, dirtyDancing.getTitle(), dirtyDancing.getMarks(), dirtyDancing.getAgeGroup()) + "\n");

        johnWick.accept(visitor);
        shrek.accept(visitor);
        dirtyDancing.accept(visitor);

        System.out.println(String.format(movieInfo, johnWick.getTitle(), johnWick.getMarks(), johnWick.getAgeGroup()));
        System.out.println(String.format(movieInfo, shrek.getTitle(), shrek.getMarks(), shrek.getAgeGroup()));
        System.out.println(String.format(movieInfo, dirtyDancing.getTitle(), dirtyDancing.getMarks(), dirtyDancing.getAgeGroup()) + "\n");
    }

    @Test
    public void observerTest() {
        Customer customer1 = new Customer("Peter", movieRental);
        Customer customer2 = new Customer("James", movieRental);

        movieRental.registerObserver(customer1);

        movieRental.setMovie(johnWick);
        movieRental.notifyObservers();

        movieRental.registerObserver(customer2);

        movieRental.setMovie(dirtyDancing);
        movieRental.notifyObservers();

        movieRental.unregisterObserver(customer2);

        movieRental.setMovie(shrek);
        movieRental.notifyObservers();
    }
}