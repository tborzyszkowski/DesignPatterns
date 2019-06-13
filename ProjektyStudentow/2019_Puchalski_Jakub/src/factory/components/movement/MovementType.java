package factory.components.movement;

public abstract class MovementType implements Cloneable{

    protected String movementType;

    public String getMovementType() {
        return movementType;
    }

    public void setMovementType(String movementType) {
        this.movementType = movementType;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        MovementType copyMovement = (MovementType) super.clone();
        return copyMovement;
    }
}
