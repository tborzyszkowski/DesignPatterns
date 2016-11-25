package task2.factories;

import task2.animals.Animal;
import task2.animals.Snake;
import task2.animals.Tyrannosaurus;

public class ReptileFactory extends SpeciesFactory {

    @Override
    public Animal getAnimal(String type) {
        if ("snake".equals(type)) {
            return new Snake();
        } else {
            return new Tyrannosaurus();
        }
    }

}

