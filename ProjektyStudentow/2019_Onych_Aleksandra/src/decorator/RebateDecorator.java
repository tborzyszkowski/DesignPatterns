package decorator;

public class RebateDecorator extends AbstractMovieDecorator {
    private final int rebatePercent;

    public RebateDecorator(int rebatePercent, AbstractMovie movie) {
        super(movie);
        this.rebatePercent = rebatePercent;
    }

    @Override
    public String toString() {
        return "decorator.RebateDecorator{" +
                "rebatePercent=" + rebatePercent +
                ", movie=" + movie +
                ", type=" + type +
                ", title='" + title + '\'' +
                ", productionYear='" + productionYear + '\'' +
                '}';
    }

    @Override
    public double getPrice() {
        int rebate = 100 - rebatePercent;
        return movie.getPrice() * rebate / 100;
    }
}
