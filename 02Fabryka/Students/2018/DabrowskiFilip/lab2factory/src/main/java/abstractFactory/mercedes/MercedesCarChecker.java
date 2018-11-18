package abstractFactory.mercedes;

import abstractFactory.CarChecker;

public class MercedesCarChecker implements CarChecker {
    public void checkEngine() {
        System.out.println("Check Mercedes engine.");
    }

    public void checkGearBox() {
        System.out.println("Check Mercedes gearbox.");
    }
}
