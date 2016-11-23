package task1;

public class CarFactory {

    private static final String AUDI = "audi";
    private static final String BMW = "bmw";

    public Car getCar(String brand) {
        switch (brand) {
            case AUDI:
                return new Audi();
            case BMW:
                return new BMW();
            default:
                throw new RuntimeException("Band not recognised");
        }
    }
}

