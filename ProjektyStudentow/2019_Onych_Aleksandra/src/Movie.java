import decorator.AbstractMovie;
import enums.MovieMark;
import enums.MovieType;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Movie extends AbstractMovie implements Cloneable, Element {
    private double price;
    private List<MovieMark> marks = new ArrayList<>();
    private boolean damaged;
    private boolean rented;
    private String ageGroup;

    public Movie(MovieBuilder builder) {
        this.type = builder.type;
        this.title = builder.title;
        this.price = builder.price;
        this.productionYear = builder.productionYear;
        this.marks = builder.marks;
        this.damaged = builder.damaged;
        this.rented = builder.rented;
        this.ageGroup = builder.ageGroup;
    }

    @Override
    public void accept(MovieVisitor visitor) {
        visitor.visit(this);
    }

    @Override
    protected Movie clone() {
        try {
            Movie movie = (Movie) super.clone();
            return movie;
        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
            return null;
        }
    }

    public double getPrice() {
        return price;
    }

    public List<MovieMark> getMarks() {
        return marks;
    }

    public String getTitle() {
        return title;
    }

    public boolean isDamaged() {
        return damaged;
    }

    public boolean isRented() {
        return rented;
    }

    public void setAgeGroup(String ageGroup) {
        this.ageGroup = ageGroup;
    }

    public void setMarks(List<MovieMark> marks) {
        this.marks = marks;
    }

    public void setDamaged(boolean damaged) {
        this.damaged = damaged;
    }

    public void setRented(boolean rented) {
        this.rented = rented;
    }

    public String getAgeGroup() {
        return ageGroup;
    }

    @Override
    public String toString() {
        return "Movie{" +
                "marks=" + marks +
                ", damaged=" + damaged +
                ", rented=" + rented +
                ", ageGroup='" + ageGroup + '\'' +
                ", type=" + type +
                ", title='" + title + '\'' +
                ", productionYear='" + productionYear + '\'' +
                ", price=" + price +
                '}';
    }

    public static class MovieBuilder {
        private MovieType type;
        private String title;
        private double price;
        private String productionYear;
        private List<MovieMark> marks = new ArrayList<>();
        private boolean damaged;
        private boolean rented;
        private String ageGroup;

        public MovieBuilder (MovieType type) {
            this.type = type;
        }

        public MovieBuilder title(String title) {
            this.title = title;
            return this;
        }

        public MovieBuilder price(double price) {
            this.price = price;
            return this;
        }

        public MovieBuilder productionYear(String year) {
            this.productionYear = year;
            return this;
        }

        public MovieBuilder marks(List<MovieMark> marks) {
            this.marks = marks;
            return this;
        }

        public MovieBuilder marks(MovieMark... marks) {
            this.marks = Arrays.asList(marks);
            return this;
        }

        public MovieBuilder damaged(boolean damaged) {
            this.damaged = damaged;
            return this;
        }

        public MovieBuilder rented(boolean rented) {
            this.rented = rented;
            return this;
        }

        public MovieBuilder ageGroup(String ageGroup) {
            this.ageGroup = ageGroup;
            return this;
        }

        public Movie build() {
            return new Movie(this);
        }
    }
}
