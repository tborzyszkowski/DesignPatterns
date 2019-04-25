package abstractFactory.factory;

import abstractFactory.parts.baskets.Basket;
import abstractFactory.parts.baskets.FrontBasket;
import abstractFactory.parts.bells.Bell;
import abstractFactory.parts.bells.ClassicBell;
import abstractFactory.parts.lamps.Lamp;
import abstractFactory.parts.lamps.LedLamp;

public class PolishPartsFactory implements PartsFactory {
    private static PolishPartsFactory polishPartsFactory;

    private PolishPartsFactory() { }

    public static PolishPartsFactory getInstance() {
        if (polishPartsFactory == null) {
            synchronized (PolishPartsFactory.class) {
                if (polishPartsFactory == null) {
                    polishPartsFactory = new PolishPartsFactory();
                }
            }
        }
        return polishPartsFactory;
    }

    public Bell createBell() {
        return new ClassicBell();
    }

    public Basket createBasket() {
        return new FrontBasket();
    }

    public Lamp createLamp() {
        return new LedLamp();
    }
}
