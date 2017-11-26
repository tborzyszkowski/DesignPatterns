package pl.devdiary.wzorce.fabryki.abstractfactory;

public class GreeceInfantry implements Infantry {
    @Override
    public void attack() {
        System.out.println("Phalangites! Hold your positions!");
    }

    @Override
    public void takeSwords() {
        System.out.println("Take your swords!");
    }
}
