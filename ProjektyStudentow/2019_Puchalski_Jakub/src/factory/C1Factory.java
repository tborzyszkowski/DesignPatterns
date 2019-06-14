package factory;

import factory.components.glass.GlassType;
import factory.components.glass.Sapphire;
import factory.components.movement.Automatic;
import factory.components.movement.MovementType;
import factory.components.strap.Leather;
import factory.components.strap.StrapType;
import watchModels.WatchModels;

public class C1Factory extends ComponentsFactory {
    @Override
    public MovementType createMovement() {
        return new Automatic();
    }

    @Override
    public WatchModels createModelName() {
        return WatchModels.C1;
    }

    @Override
    public GlassType createGlass() {
        return new Sapphire();
    }

    @Override
    public StrapType createStrap() {
        return new Leather();
    }

    @Override
    public Boolean createDateWheel() {
        return true;
    }

    @Override
    public Boolean createChronograf() {
        return true;
    }

    @Override
    public Boolean createWatertigness() {
        return true;
    }

    @Override
    public double createVolumePrice() {
        return 1200;
    }
}
