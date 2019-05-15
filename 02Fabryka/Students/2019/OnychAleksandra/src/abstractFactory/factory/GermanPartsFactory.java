package abstractFactory.factory;

import abstractFactory.parts.baskets.BackBasket;
import abstractFactory.parts.baskets.Basket;
import abstractFactory.parts.bells.AirHornBell;
import abstractFactory.parts.bells.Bell;
import abstractFactory.parts.lamps.Lamp;
import abstractFactory.parts.lamps.ReflectiveLamp;

public class GermanPartsFactory implements PartsFactory {
    private static GermanPartsFactory germanPartsFactory;

    private GermanPartsFactory() { }

    public static GermanPartsFactory getInstance() {
        if (germanPartsFactory == null) {
            synchronized (GermanPartsFactory.class) {
                if (germanPartsFactory == null) {
                    germanPartsFactory = new GermanPartsFactory();
                }
            }
        }
        return germanPartsFactory;
    }

    public Bell createBell() {
        return new AirHornBell();
    }

    public Basket createBasket() {
        return new BackBasket();
    }

    public Lamp createLamp() {
        return new ReflectiveLamp();
    }
}
