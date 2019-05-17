package AbstractFactory.ComponentsFactory;

import AbstractFactory.ComponentsFactory.Components.Fabric.*;
import AbstractFactory.ComponentsFactory.Components.Tie.*;
import AbstractFactory.ComponentsFactory.Components.Sole.*;

public class RunningComponentsFactory implements ComponentsFactory {
    @Override
    public Sole createSole() {
        return new DropSole();
    }

    @Override
    public Fabric createFabric() {
        return new SynteticTextileFabric();
    }

    @Override
    public Tie createTie() {
        return new LacesTie();
    }
}
