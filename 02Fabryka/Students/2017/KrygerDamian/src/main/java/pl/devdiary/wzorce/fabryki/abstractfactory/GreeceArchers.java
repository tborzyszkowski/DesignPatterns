package pl.devdiary.wzorce.fabryki.abstractfactory;

public class GreeceArchers implements Archers {
    @Override
    public void attack() {
        System.out.println("Greece archers! Aim... Fire!");
    }

    @Override
    public void takeBows() { System.out.println("Take greece bows!"); }
}
