package DeepPrototype;

public class Watch implements Cloneable {

    private Movement movementType;
    private Strap strapType;
    private Glass glassType;

    public Watch(Movement movementType, Strap strapType, Glass glassType) {
        this.movementType = movementType;
        this.strapType = strapType;
        this.glassType = glassType;
    }

    public Movement getMovementType() {
        return movementType;
    }

    public void setMovementType(Movement movementType) {
        this.movementType = movementType;
    }

    public Strap getStrapType() {
        return strapType;
    }

    public void setStrapType(Strap strapType) {
        this.strapType = strapType;
    }

    public Glass getGlassType() {
        return glassType;
    }

    public void setGlassType(Glass glassType) {
        this.glassType = glassType;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {

        Watch copyWatch = (Watch) super.clone();
        copyWatch.glassType = (Glass) glassType.clone();
        copyWatch.strapType = (Strap) strapType.clone();
        copyWatch.movementType = (Movement) movementType.clone();
        return copyWatch;
    }
}
