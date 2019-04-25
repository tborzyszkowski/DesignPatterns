package decorator;

import enums.MovieType;

public abstract class AbstractMovie {
    public MovieType type;
    public String title;
    public String productionYear;

    public abstract double getPrice();
}
