import enums.MovieMark;
import enums.MovieType;

import java.util.HashMap;
import java.util.Map;

public class MovieManager {

    Map<String, Movie> movies = new HashMap<>();

    {
        movies.put("John Wick",
                new Movie.MovieBuilder(MovieType.ACTION)
                        .title("John Wick")
                        .productionYear("2014")
                        .price(15.50)
                        .damaged(false)
                        .rented(false)
                        .marks(MovieMark.VIOLENCE, MovieMark.LANGUAGE)
                        .build());

        movies.put("Shrek",
                new Movie.MovieBuilder(MovieType.ANIMATED)
                        .title("Shrek")
                        .productionYear("2001")
                        .price(8)
                        .damaged(true)
                        .rented(false)
                        .build());

        movies.put("Dirty Dancing",
                new Movie.MovieBuilder(MovieType.ROMANCE)
                        .title("Dirty Dancing")
                        .productionYear("1987")
                        .price(10.5)
                        .damaged(false)
                        .rented(true)
                        .marks(MovieMark.NUDITY)
                        .build()
        );
    }

    public Movie getMoviePrototype(String title) {
        return movies.get(title).clone();
    }
}
