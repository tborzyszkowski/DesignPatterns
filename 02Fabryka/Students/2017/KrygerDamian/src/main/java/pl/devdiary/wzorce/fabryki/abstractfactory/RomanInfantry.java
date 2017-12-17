package pl.devdiary.wzorce.fabryki.abstractfactory;

public class RomanInfantry implements Infantry {
    @Override
    public void attack() {
        System.out.println("Principes! Throw your pilums!");
    }

    @Override
    public void takeSwords() {
        System.out.println("Take your Gladius!");
    }
}
