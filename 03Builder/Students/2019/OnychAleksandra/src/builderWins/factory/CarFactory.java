package builderWins.factory;

public class CarFactory implements CarAbstractFactory {

    private static CarFactory carFactory;

    private CarFactory() {}

    public static CarFactory getInstance() {
        if (carFactory == null) {
            synchronized (CarFactory.class) {
                if (carFactory == null) {
                    carFactory = new CarFactory();
                }
            }
        }
        return carFactory;
    }

    public CarBase makeCar(String brand) {
        switch (brand.toUpperCase()) {
            case "AUDI" :
                return new Audi();
            case "FORD" :
                return new Ford();
            case "CHEVROLET" :
                return new Chevrolet();
            default :
                return null;
        }
    }
}
