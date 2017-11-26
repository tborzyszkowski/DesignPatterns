package pl.devdiary.wzorce.fabryki.factorymethod;

public class GreeceInfantry implements Army {
    @Override
    public void attack() {
        System.out.println("Phalangites! Hold your positions!");
    }
}
