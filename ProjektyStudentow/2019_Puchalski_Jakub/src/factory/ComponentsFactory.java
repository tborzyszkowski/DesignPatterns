package factory;

import factory.components.glass.GlassType;
import factory.components.movement.MovementType;
import factory.components.strap.StrapType;
import watchModels.WatchModels;

public abstract class ComponentsFactory {
    public abstract MovementType createMovement();
    public abstract WatchModels createModelName();
    public abstract GlassType createGlass();
    public abstract StrapType createStrap();
    public abstract Boolean createDateWheel();
    public abstract Boolean createChronograf();
    public abstract Boolean createWatertigness();
    public abstract double createVolumePrice();
}
