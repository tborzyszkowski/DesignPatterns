package wytworcza;

public class ActionMovieFactory extends MovieFactory {
	private static ActionMovieFactory instance;

	private ActionMovieFactory() {
	}

	public static ActionMovieFactory getInstance() {
		if (instance == null) {
			instance = new ActionMovieFactory();
		}
		return instance;
	}

	@Override
	public Movie createMovie(MovieType movieType) {
		switch (movieType) {
		case JohnWick:
			return new JohnWick();
		case Rambo:
			return new Rambo();
		default:
			return null;
		}
	}

}
