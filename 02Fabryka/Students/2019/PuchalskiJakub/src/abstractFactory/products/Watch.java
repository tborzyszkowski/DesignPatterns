package abstractFactory.products;

import abstractFactory.components.glass.Glass;
import abstractFactory.components.movement.Movement;
import abstractFactory.components.strap.Strap;

public abstract class Watch {

    protected String producer;
    protected Float price;

    protected String type;
    protected Glass glass;
    protected Movement movement;
    protected Strap strap;

    @Override
    public String toString() {
        return
                type + "\n" +
                producer + " Watch" + "\n" +
                "Cost: " + price + "\n" +
                "Components: \n" +
                "Movement: " + movement + "\n" +
                "Glass: " + glass + "\n" +
                "Strap: " + strap;
    }
}
