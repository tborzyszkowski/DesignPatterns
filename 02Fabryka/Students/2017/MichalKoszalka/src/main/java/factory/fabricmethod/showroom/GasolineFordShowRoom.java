package factory.fabricmethod.showroom;

import factory.common.exception.UnsupportedCarTypeException;
import factory.fabricmethod.car.gasoline.GasolineFordCMax;
import factory.fabricmethod.car.gasoline.GasolineFordFiesta;
import factory.fabricmethod.car.gasoline.GasolineFordMustang;
import factory.simple.Ford;

public class GasolineFordShowRoom extends FordShowRoom {

    @Override
    Ford createFord(String item) {
        if(item.equalsIgnoreCase("fiesta")) {
            return new GasolineFordFiesta();
        } else if(item.equalsIgnoreCase("mustang")) {
            return new GasolineFordMustang();
        } else if(item.equalsIgnoreCase("cmax")) {
            return new GasolineFordCMax();
        } else {
            throw new UnsupportedCarTypeException("type: " + item + " not supported ");
        }
    }
}
