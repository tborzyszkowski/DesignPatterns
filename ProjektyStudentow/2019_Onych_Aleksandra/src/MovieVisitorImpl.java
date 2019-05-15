import enums.MovieMark;

public class MovieVisitorImpl implements MovieVisitor {

    @Override
    public void visit(Movie movie) {
        if (movie.getMarks().isEmpty()) {
            movie.setAgeGroup("appropriate for children");
        } else if (!movie.getMarks().contains(MovieMark.VIOLENCE) && !movie.getMarks().contains(MovieMark.EROTIC)) {
            movie.setAgeGroup("+13");
        } else if (!movie.getMarks().contains(MovieMark.EROTIC)) {
            movie.setAgeGroup("+16");
        } else {
            movie.setAgeGroup("+18");
        }
    }
}
