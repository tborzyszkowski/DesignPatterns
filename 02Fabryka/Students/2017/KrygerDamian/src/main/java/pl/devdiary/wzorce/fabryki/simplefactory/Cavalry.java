package pl.devdiary.wzorce.fabryki.simplefactory;

public class Cavalry implements Army {
    @Override
    public void attack() {
        System.out.println("Charge!!!");
    }
}
