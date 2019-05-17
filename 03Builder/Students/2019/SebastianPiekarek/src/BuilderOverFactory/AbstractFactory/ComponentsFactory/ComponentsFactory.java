package BuilderOverFactory.AbstractFactory.ComponentsFactory;

import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Fabric.Fabric;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Laces.Tie;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Sole.Sole;


public interface ComponentsFactory {

    Sole createSole(int price);
    Fabric createFabric(String color);
    Tie createLaces(int price);
}
