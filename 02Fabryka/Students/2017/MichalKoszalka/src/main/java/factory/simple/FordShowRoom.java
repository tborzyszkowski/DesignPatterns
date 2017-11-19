package factory.simple;

public class FordShowRoom {

    SimpleFordFactory factory;

    public FordShowRoom(SimpleFordFactory factory) {
        this.factory = factory;
    }

    public Ford orderFord(String type) {
        Ford ford = factory.createFord(type);

        ford.refuel();
        ford.prepareTires();

        return ford;
    }

}
