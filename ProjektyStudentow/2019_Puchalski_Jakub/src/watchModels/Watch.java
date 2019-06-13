package watchModels;

import factory.ComponentsFactory;
import factory.components.glass.GlassType;
import factory.components.movement.MovementType;
import factory.components.strap.StrapType;

public class Watch implements Cloneable{

    public long id;
    public WatchModels model;
    public MovementType movementType;
    public GlassType glassType;
    public StrapType strapType;
    public boolean dateWheel;
    public boolean chronograf;
    public boolean watertightness;
    public double volumePrice;
    public boolean gift = false;

    private ComponentsFactory componentsFactory;

    public Watch(){};

    public Watch(ComponentsFactory componentsFactory){
        id = hashCode();
        this.componentsFactory = componentsFactory;
        createWatch();
    }

    private void createWatch() {

        model = componentsFactory.createModelName();
        movementType = componentsFactory.createMovement();
        glassType = componentsFactory.createGlass();
        strapType = componentsFactory.createStrap();
        dateWheel = componentsFactory.createDateWheel();
        chronograf = componentsFactory.createChronograf();
        watertightness = componentsFactory.createWatertigness();
        volumePrice = componentsFactory.createVolumePrice();

    }

    @Override
    public String toString() {
        return "models.Watch{" +
                "id= " + id + ", model= " + model  +
                ", movementType= " + movementType.getMovementType() +
                ", glassType= " + glassType.getGlassType() +
                ", strapType= " + strapType.getStrapType() +
                ", dateWheel= " + dateWheel +
                ", chronograf= " + chronograf +
                ", watertightness= " + watertightness +
                ", volume price= " + volumePrice +
                '}';
    }

    @Override
    public Object clone() throws CloneNotSupportedException {

        Watch copyWatch = (Watch) super.clone();
        copyWatch.id = copyWatch.hashCode();
        copyWatch.glassType = (GlassType) glassType.clone();
        copyWatch.strapType = (StrapType) strapType.clone();
        copyWatch.movementType = (MovementType) movementType.clone();
        return copyWatch;
    }

}
