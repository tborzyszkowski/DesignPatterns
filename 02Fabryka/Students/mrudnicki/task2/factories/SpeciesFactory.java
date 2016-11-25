package task2.factories;

import task2.animals.Animal;

public abstract class SpeciesFactory {
    public abstract Animal getAnimal(String type);
}

