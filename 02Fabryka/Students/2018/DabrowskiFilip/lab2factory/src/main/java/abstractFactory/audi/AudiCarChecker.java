package abstractFactory.audi;

import abstractFactory.CarChecker;

public class AudiCarChecker implements CarChecker {
    public void checkEngine() {
        System.out.println("Check Audi engine.");
    }

    public void checkGearBox() {
        System.out.println("Check Audi gearbox.");
    }
}
