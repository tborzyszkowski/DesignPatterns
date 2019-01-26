package abstractFactory.audi;

import abstractFactory.CarCleaner;

public class AudiCarCleaner implements CarCleaner {
    public void cleanCar() {
        System.out.println("Clean Audi.");
    }
}
