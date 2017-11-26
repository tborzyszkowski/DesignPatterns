package pl.devdiary.wzorce.fabryki.abstractfactory;

public class RomanArchers implements Archers {

    @Override
    public void attack() {
        System.out.println("Roman archers! Aim... Fire!");
    }

    @Override
    public void takeBows() {
        System.out.println("Take your bows!");
    }
}
