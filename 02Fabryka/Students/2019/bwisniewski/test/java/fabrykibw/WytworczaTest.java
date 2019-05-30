package fabrykibw;

import static org.junit.Assert.assertEquals;

import org.junit.Before;
import org.junit.Test;

import wytworcza.ActionMovieFactory;
import wytworcza.Movie;
import wytworcza.MovieFactory;
import wytworcza.MovieType;
import wytworcza.SFMovieFactory;

public class WytworczaTest {

	MovieFactory sFMovieFactory;
	MovieFactory actionMovieFactory;

	@Before
	public void setup() {
		sFMovieFactory = SFMovieFactory.getInstance();
		actionMovieFactory = ActionMovieFactory.getInstance();
	}

	@Test
	public void starWarsTest() {
		Movie starWars = sFMovieFactory.createMovie(MovieType.StarWars);
		assertEquals(starWars.getType(), "StarWars");
	}

	@Test
	public void starTrekTest() {
		Movie starTrek = sFMovieFactory.createMovie(MovieType.StarTrek);
		assertEquals(starTrek.getType(), "StarTrek");
	}

	@Test
	public void ramboTest() {
		Movie rambo = actionMovieFactory.createMovie(MovieType.Rambo);
		assertEquals(rambo.getType(), "Rambo");
	}

	@Test
	public void johnWickTest() {
		Movie johnWick = actionMovieFactory.createMovie(MovieType.JohnWick);
		assertEquals(johnWick.getType(), "JohnWick");
	}
	@Test
    public void timeTest() {
        long start = System.currentTimeMillis();
        for(int i = 0 ; i<1000000 ; i++){
        	actionMovieFactory.createMovie(MovieType.JohnWick);
        }
        long koniec = System.currentTimeMillis();
        System.out.println("Wytworcza czas: " + (koniec - start));
    }
	
}