package factory.fabricmethod;

import factory.common.exception.UnsupportedCarTypeException;
import factory.fabricmethod.showroom.GasolineFordShowRoom;
import factory.fabricmethod.showroom.OilFordShowRoom;
import factory.simple.Ford;

public class Test {

    public static void main(String[] args) {
        // TODO Auto-generated method stub
        GasolineFordShowRoom gasolineFordShowRoom = new GasolineFordShowRoom();
        OilFordShowRoom oilFordShowRoom = new OilFordShowRoom();

        Ford ford = gasolineFordShowRoom.orderFord("mustang");
        System.out.println("ford " + ford.getModel() + " ordered");

        ford = gasolineFordShowRoom.orderFord("cmax");
        System.out.println("ford " + ford.getModel() + " ordered");

        ford = gasolineFordShowRoom.orderFord("fiesta");
        System.out.println("ford " + ford.getModel() + " ordered");

        try {
            ford = gasolineFordShowRoom.orderFord("focus");
            System.out.println("ford " + ford.getModel() + " ordered");
        } catch (UnsupportedCarTypeException ex) {
            System.out.println(ex.getMessage());
        }

        ford = oilFordShowRoom.orderFord("mustang");
        System.out.println("ford " + ford.getModel() + " ordered");

        ford = oilFordShowRoom.orderFord("cmax");
        System.out.println("ford " + ford.getModel() + " ordered");

        ford = oilFordShowRoom.orderFord("fiesta");
        System.out.println("ford " + ford.getModel() + " ordered");

        try {
            ford = oilFordShowRoom.orderFord("focus");
            System.out.println("ford " + ford.getModel() + " ordered");
        } catch (UnsupportedCarTypeException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
