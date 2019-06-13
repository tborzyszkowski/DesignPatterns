package abstractFactory.components;

import abstractFactory.components.glass.Glass;
import abstractFactory.components.glass.Sapphire;
import abstractFactory.components.movement.Automatic;
import abstractFactory.components.movement.Movement;
import abstractFactory.components.strap.Leather;
import abstractFactory.components.strap.Strap;

public class PremiumWatchComponentsFactory implements ComponentsFactory {
    @Override
    public String createType() {
        return "Premiu";
    }

    @Override
    public Movement createMovement() {
        return new Automatic();
    }

    @Override
    public Glass createGlass() {
        return new Sapphire();
    }

    @Override
    public Strap createStrap() {
        return new Leather();
    }
}
