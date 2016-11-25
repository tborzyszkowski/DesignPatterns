package task2.factories;

public class AbstractFactory {

    public SpeciesFactory getSpeciesFactory(String type) {
        if ("mammal".equals(type)) {
            return new MammalFactory();
        } else {
            return new ReptileFactory();
        }
    }

}

