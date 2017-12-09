package factory.fabricmethod.showroom;

import factory.simple.Ford;

public abstract class FordShowRoom {

    abstract Ford createFord(String item);

    public Ford orderFord(String type) {
        Ford ford = createFord(type);
        System.out.println("creating a ford " + ford.getModel());
        ford.refuel();
        ford.prepareTires();
        return ford;
    }

}
