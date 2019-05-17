package AbstractFactory.ComponentsFactory;

import AbstractFactory.ComponentsFactory.Components.Fabric.*;
import AbstractFactory.ComponentsFactory.Components.Tie.*;
import AbstractFactory.ComponentsFactory.Components.Sole.*;

public class BasketballComponentsFactory implements ComponentsFactory {
    @Override
    public Sole createSole() {
        return new SpringySole();
    }

    @Override
    public Fabric createFabric() {
        return new SynteticFabric();
    }

    @Override
    public Tie createTie() {
        return new VelcroTie();
    }
}
