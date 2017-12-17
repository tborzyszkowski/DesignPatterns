package pl.devdiary.wzorce.fabryki.simplefactory;

public class Archers implements Army {
    @Override
    public void attack() {
        System.out.println("Aim... Fire!");
    }
}
