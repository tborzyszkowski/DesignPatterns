package FactoryOverBuilder.AbstractFactory.ComponentsFactory;

import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Fabric.Fabric;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Fabric.SynteticTextileFabric;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Laces.LacesTie;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Laces.Tie;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Sole.DropSole;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Sole.Sole;

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
    public Tie createLaces() {
        return new LacesTie();
    }
}
