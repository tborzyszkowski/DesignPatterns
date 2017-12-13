package factory.fabricmethod.showroom;

import factory.common.exception.UnsupportedCarTypeException;
import factory.fabricmethod.car.gasoline.GasolineFordCMax;
import factory.fabricmethod.car.gasoline.GasolineFordFiesta;
import factory.fabricmethod.car.gasoline.GasolineFordMustang;
import factory.fabricmethod.car.oil.OilFordCMax;
import factory.fabricmethod.car.oil.OilFordFiesta;
import factory.fabricmethod.car.oil.OilFordMustang;
import factory.simple.Ford;

public class AllFordShowRoom {

    Ford createFord(String petrolType, String type) {
        Ford ford = null;
        if (petrolType.equalsIgnoreCase("gasoline")) {
            if (type.equalsIgnoreCase("fiesta")) {
                ford = new GasolineFordFiesta();
            } else if (type.equalsIgnoreCase("mustang")) {
                ford = new GasolineFordMustang();
            } else if (type.equalsIgnoreCase("cmax")) {
                ford = new GasolineFordCMax();
            }
        } else if (petrolType.equalsIgnoreCase("oil")) {
            if (type.equalsIgnoreCase("fiesta")) {
                ford = new OilFordFiesta();
            } else if (type.equalsIgnoreCase("mustang")) {
                ford = new OilFordMustang();
            } else if (type.equalsIgnoreCase("cmax")) {
                ford = new OilFordCMax();
            }
        } else {
            throw new UnsupportedCarTypeException("type: " + type + " not supported ");
        }
        ford.refuel();
        ford.prepareTires();
        return ford;
    }

}
