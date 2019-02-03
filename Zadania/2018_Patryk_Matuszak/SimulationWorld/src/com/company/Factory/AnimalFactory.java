package com.company.Factory;

public class AnimalFactory {
    public static Animal getAnimal(AnimalFactoryProtocol protocol) {
        return protocol.getAnimal();
    }
}
