package pl.devdiary.wzorce.fabryki.simplefactory;

public class SimpleArmyFactory {

    public Army createArmy(ArmyType type) {
        switch(type) {
            case INFANTRY:
                return new Infantry();
            case CAVALRY:
                return new Cavalry();
            case ARCHERS:
                return new Archers();
            default:
                throw new IllegalArgumentException("Nie ma takiego typu.");
        }
    }
}
