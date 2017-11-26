package pl.devdiary.wzorce.fabryki.factorymethod;

public class RomanArchers implements Army {

    @Override
    public void attack() {
        System.out.println("Roman archers! Aim... Fire!");
    }
}
