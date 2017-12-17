package pl.devdiary.wzorce.fabryki.factorymethod;

public class RomanCavalry implements Army {
    @Override
    public void attack() {
        System.out.println("For Mars! Charge!");
    }
}
