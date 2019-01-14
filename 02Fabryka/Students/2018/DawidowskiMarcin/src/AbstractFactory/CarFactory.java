package AbstractFactory;

public class CarFactory {
    public static Car getCar(CarAbstractFactory factory){
        return factory.showCar();
    }
}
