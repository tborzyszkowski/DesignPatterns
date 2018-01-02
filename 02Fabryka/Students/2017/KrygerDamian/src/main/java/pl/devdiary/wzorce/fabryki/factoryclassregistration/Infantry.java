package pl.devdiary.wzorce.fabryki.factoryclassregistration;

public class Infantry implements Army {

    static {
        ArmyFactory.getInstance().registerClass(ArmyType.INFANTRY, Infantry.class);
    }

    static public Army createArmy() {
        return new Infantry();
    }

    @Override
    public void attack() {
        System.out.println("Attack!");
    }
}
