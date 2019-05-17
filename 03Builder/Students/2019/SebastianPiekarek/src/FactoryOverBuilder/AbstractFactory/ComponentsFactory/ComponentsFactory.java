package FactoryOverBuilder.AbstractFactory.ComponentsFactory;

import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Fabric.Fabric;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Laces.Tie;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Sole.Sole;


public interface ComponentsFactory {

    Sole createSole();
    Fabric createFabric();
    Tie createLaces();
}
