package pl.devdiary.wzorce.fabryki.simplefactory;

public class Infantry implements Army {
    @Override
    public void attack() {
        System.out.println("attack!!!");
    }
}
