package pl.devdiary.wzorce.fabryki.factoryclassregistration;

public class Archers implements Army {

    static {
        ArmyFactory.getInstance().registerClass(ArmyType.ARCHERS, Archers.class);
    }

    static public Army createArmy() {
        return new Archers();
    }

    @Override
    public void attack() {
        System.out.println("Aim... Fire!");
    }
}
