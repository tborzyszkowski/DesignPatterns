package pl.devdiary.wzorce.fabryki.factoryclassregistration;

public class Cavarly implements Army {

    static {
        ArmyFactory.getInstance().registerClass(ArmyType.CAVARLY, Cavarly.class);
    }

    static public Army createArmy() {
        return new Cavarly();
    }

    @Override
    public void attack() {
        System.out.println("Charge!");
    }
}
