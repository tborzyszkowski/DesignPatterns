package abstractFactory;

public abstract class CarServiceFactory {

    abstract public CarChecker getCarChecker();

    abstract public CarCleaner getCarCleaner();

}
