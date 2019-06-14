package factoryMethod.products;

import abstractFactory.components.glass.Glass;
import abstractFactory.components.movement.Movement;
import abstractFactory.components.strap.Strap;

public abstract class Watch {

    protected String producer;
    protected Float price;
    protected String type;


    @Override
    public String toString() {
        return
                type + "\n" +
                producer + " Watch" + "\n" +
                "Cost: " + price + "\n";
    }
}
