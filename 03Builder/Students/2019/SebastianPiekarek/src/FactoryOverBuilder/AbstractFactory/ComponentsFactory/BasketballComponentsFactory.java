package FactoryOverBuilder.AbstractFactory.ComponentsFactory;

import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Fabric.Fabric;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Fabric.SynteticFabric;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Laces.Tie;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Laces.VelcroTie;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Sole.Sole;
import FactoryOverBuilder.AbstractFactory.ComponentsFactory.Components.Sole.SpringySole;

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
    public Tie createLaces() {
        return new VelcroTie();
    }
}
