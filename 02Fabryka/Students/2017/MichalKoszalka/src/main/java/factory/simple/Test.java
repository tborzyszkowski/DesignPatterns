package factory.simple;

import factory.common.exception.UnsupportedCarTypeException;

public class Test {

    public static void main(String[] args) {
        // TODO Auto-generated method stub
        SimpleFordFactory factory = new SimpleFordFactory();
        FordShowRoom fordShowRoom = new FordShowRoom(factory);

        Ford ford = fordShowRoom.orderFord("mustang");
        System.out.println("ford " + ford.getModel() + " ordered");

        ford = fordShowRoom.orderFord("cmax");
        System.out.println("ford " + ford.getModel() + " ordered");

        ford = fordShowRoom.orderFord("fiesta");
        System.out.println("ford " + ford.getModel() + " ordered");

        try {
            ford = fordShowRoom.orderFord("focus");
            System.out.println("ford " + ford.getModel() + " ordered");
        } catch (UnsupportedCarTypeException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
