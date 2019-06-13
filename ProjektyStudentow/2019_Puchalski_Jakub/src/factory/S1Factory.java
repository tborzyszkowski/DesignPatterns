package factory;

import factory.components.glass.GlassType;
import factory.components.glass.Mineral;
import factory.components.movement.MovementType;
import factory.components.movement.Quartz;
import factory.components.strap.Rubber;
import factory.components.strap.StrapType;
import watchModels.WatchModels;

public class S1Factory extends ComponentsFactory {
    @Override
    public MovementType createMovement() {
        return new Quartz();
    }

    @Override
    public WatchModels createModelName() {
        return WatchModels.S1;
    }

    @Override
    public GlassType createGlass() {
        return new Mineral();
    }

    @Override
    public StrapType createStrap() {
        return new Rubber();
    }

    @Override
    public Boolean createDateWheel() {
        return false;
    }

    @Override
    public Boolean createChronograf() {
        return false;
    }

    @Override
    public Boolean createWatertigness() {
        return false;
    }

    @Override
    public double createVolumePrice() {
        return 1000f;
    }
}
