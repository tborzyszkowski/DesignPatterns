package pl.devdiary.wzorce.fabryki.abstractfactory;

public class GreeceCavalry implements Cavalry {
    @Override
    public void attack() {
        System.out.println("For Ares! Charge!");
    }

    @Override
    public void mount() {
        System.out.println("Get on horse!!!");
    }
}
