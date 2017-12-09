package factory.simple;

import factory.common.exception.UnsupportedCarTypeException;

public class SimpleFordFactory {

    public Ford createFord(String type) {
        if(type.equalsIgnoreCase("fiesta")) {
            return new Fiesta();
        } else if(type.equalsIgnoreCase("mustang")) {
            return new Mustang();
        } else if(type.equalsIgnoreCase("cmax")) {
            return new CMax();
        } else {
            throw new UnsupportedCarTypeException("type: " + type + " not supported ");
        }
    }

}
