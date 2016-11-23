package task2.factories;

import task2.animals.Animal;
import task2.animals.Cat;
import task2.animals.Dog;

public class MammalFactory extends SpeciesFactory {

    @Override
    public Animal getAnimal(String type) {
        if ("dog".equals(type)) {
            return new Dog();
        } else {
            return new Cat();
        }
    }

}

