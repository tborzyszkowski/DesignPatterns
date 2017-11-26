package pl.devdiary.wzorce.fabryki.abstractfactory;

public class RomanBarracks implements AbstractArmyFactory {

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
