package pl.devdiary.wzorce.fabryki.factorymethod;

public class RomanBarracks implements Barracks {
    @Override
    public Army trainUnit(ArmyType type) {
        switch (type)
        {
            case INFANTRY:
                return new RomanInfantry();
            case ARCHERS:
                return new RomanArchers();
            case CAVALRY:
                return new RomanCavalry();
            default:
                throw new IllegalArgumentException("Nie ma takiego typu.");
        }
    }
}
