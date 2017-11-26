package pl.devdiary.wzorce.fabryki.abstractfactory;

public class GreeceBarracks implements AbstractArmyFactory {
    @Override
    public Army trainUnit(ArmyType type) {
        switch (type)
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
