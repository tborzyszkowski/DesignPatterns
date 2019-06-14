package abstractFactory.components;

import abstractFactory.components.glass.Glass;
import abstractFactory.components.glass.Hesalite;
import abstractFactory.components.movement.Movement;
import abstractFactory.components.movement.Quartz;
import abstractFactory.components.strap.Metal;
import abstractFactory.components.strap.Strap;

public class CasualWatchComponentsFactory implements ComponentsFactory {

    @Override
    public String createType() {
        return "Casual";
    }

    @Override
    public Movement createMovement() {
        return new Quartz();
    }

    @Override
    public Glass createGlass() {
        return new Hesalite();
    }

    @Override
    public Strap createStrap() {
        return new Metal();
    }
}
