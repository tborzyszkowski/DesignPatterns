package BuilderOverFactory.AbstractFactory.ComponentsFactory;

import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Fabric.Fabric;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Fabric.SynteticFabric;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Fabric.SynteticTextileFabric;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Laces.LacesTie;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Laces.Tie;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Laces.VelcroTie;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Sole.DropSole;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Sole.Sole;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Sole.SpringySole;

public class FootballComponentsFactory implements ComponentsFactory {

    String[] colors = new String[] {"czerwony", "biały", "czarny"};

    @Override
    public Sole createSole(int price) {
        return price > 1000 ? new SpringySole() : new DropSole();
    }

    @Override
    public Fabric createFabric(String color) {

        for (String available : colors) {
            if (color == available) return new SynteticTextileFabric();
        }
        return new SynteticFabric();
    }

    @Override
    public Tie createLaces(int price) {
        return price > 1000 ? new VelcroTie() : new LacesTie();
    }
}
