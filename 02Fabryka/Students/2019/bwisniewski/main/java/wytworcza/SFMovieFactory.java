package wytworcza;

public class SFMovieFactory extends MovieFactory {

	private static SFMovieFactory instance;

	private SFMovieFactory() {
	}

	public static SFMovieFactory getInstance() {
		if (instance == null) {
			instance = new SFMovieFactory();
		}
		return instance;
	}

	@Override
	public Movie createMovie(MovieType movieType) {
		switch (movieType) {
		case StarWars:
			return new StarWars();
		case StarTrek:
			return new StarTrek();
		default:
			return null;
		}
	}

}
