package pl.devdiary.wzorce.fabryki.factorymethod;

public class RomanInfantry implements Army {
    @Override
    public void attack() {
        System.out.println("Principes! Throw your pilums!");
    }
}
