package abstractFactory.factory;

import abstractFactory.parts.baskets.Basket;
import abstractFactory.parts.bells.Bell;
import abstractFactory.parts.lamps.Lamp;

public interface PartsFactory {

    Bell createBell();
    Basket createBasket();
    Lamp createLamp();

}
