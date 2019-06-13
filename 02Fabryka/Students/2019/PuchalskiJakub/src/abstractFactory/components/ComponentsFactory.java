package abstractFactory.components;

import abstractFactory.components.glass.Glass;
import abstractFactory.components.movement.Movement;
import abstractFactory.components.strap.Strap;

public interface ComponentsFactory {
    String createType();
    Movement createMovement();
    Glass createGlass();
    Strap createStrap();
}
