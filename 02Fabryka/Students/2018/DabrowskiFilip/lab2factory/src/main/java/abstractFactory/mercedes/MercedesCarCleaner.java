package abstractFactory.mercedes;

import abstractFactory.CarCleaner;

public class MercedesCarCleaner implements CarCleaner {
    public void cleanCar() {
        System.out.println("Clean Mercedes.");
    }
}
