package abstractFactory.components;

import abstractFactory.components.glass.Glass;
import abstractFactory.components.glass.Mineral;
import abstractFactory.components.movement.Movement;
import abstractFactory.components.movement.Quartz;
import abstractFactory.components.strap.Rubber;
import abstractFactory.components.strap.Strap;

public class SportWatchComponentsFactory implements ComponentsFactory {
    @Override
    public String createType() {
        return "Sport";
    }

    @Override
    public Movement createMovement() {
        return new Quartz();
    }

    @Override
    public Glass createGlass() {
        return new Mineral();
    }

    @Override
    public Strap createStrap() {
        return new Rubber();
    }
}
