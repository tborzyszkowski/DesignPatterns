package AbstractFactory.ComponentsFactory;

import AbstractFactory.ComponentsFactory.Components.Fabric.Fabric;
import AbstractFactory.ComponentsFactory.Components.Tie.Tie;
import AbstractFactory.ComponentsFactory.Components.Sole.Sole;


public interface ComponentsFactory {

    Sole createSole();
    Fabric createFabric();
    Tie createTie();
}
