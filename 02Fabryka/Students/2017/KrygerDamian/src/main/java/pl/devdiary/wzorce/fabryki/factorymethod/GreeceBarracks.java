package pl.devdiary.wzorce.fabryki.factorymethod;

public class GreeceBarracks implements Barracks {
    @Override
    public Army trainUnit(ArmyType type) {
        switch(type)
        {
            case INFANTRY:
                return new GreeceInfantry();
            case ARCHERS:
                return new GreeceArchers();
            case CAVALRY:
                return new GreeceCavalry();
            default:
                throw new IllegalArgumentException("Nie ma takiego typu.");
        }
    }
}
