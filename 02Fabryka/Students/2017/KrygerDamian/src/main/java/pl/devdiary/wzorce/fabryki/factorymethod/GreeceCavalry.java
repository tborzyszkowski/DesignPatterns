package pl.devdiary.wzorce.fabryki.factorymethod;

public class GreeceCavalry implements Army {
    @Override
    public void attack() {
        System.out.println("For Ares! Charge!");
    }
}
