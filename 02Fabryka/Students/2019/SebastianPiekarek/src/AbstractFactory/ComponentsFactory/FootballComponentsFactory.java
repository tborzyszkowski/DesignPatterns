package AbstractFactory.ComponentsFactory;

import AbstractFactory.ComponentsFactory.Components.Fabric.Fabric;
import AbstractFactory.ComponentsFactory.Components.Fabric.SynteticTextileFabric;
import AbstractFactory.ComponentsFactory.Components.Tie.Tie;
import AbstractFactory.ComponentsFactory.Components.Tie.LacesTie;
import AbstractFactory.ComponentsFactory.Components.Sole.Sole;
import AbstractFactory.ComponentsFactory.Components.Sole.SpringySole;

public class FootballComponentsFactory implements ComponentsFactory{
    @Override
    public Sole createSole() {
        return new SpringySole();
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
