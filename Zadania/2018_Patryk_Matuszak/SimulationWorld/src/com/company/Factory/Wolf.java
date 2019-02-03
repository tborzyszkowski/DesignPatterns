package com.company.Factory;

public class Wolf extends Animal implements AnimalFactoryProtocol {

    public Wolf() {
        super.name = 'W';
    }

    @Override
    public Animal getAnimal() {
        return new Wolf();
    }
}
