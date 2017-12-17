package pl.devdiary.wzorce.fabryki.factorymethod;

public class GreeceArchers implements Army {
    @Override
    public void attack() {
        System.out.println("Greece archers! Aim... Fire!");
    }
}
