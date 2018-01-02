package pl.devdiary.wzorce.fabryki.abstractfactory;

public class RomanCavalry implements Cavalry {
    @Override
    public void attack() {
        System.out.println("For Mars! Charge!");
    }

    @Override
    public void mount() {
        System.out.println("Get on horse!");
    }
}
