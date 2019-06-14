package DeepPrototype;

public class Movement implements Cloneable {

    private String type;

    public Movement(String movementType) {
        this.type = movementType;
    }

    public String getMovementType() {
        return type;
    }

    public void setMovementType(String movementType) {
        this.type = movementType;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {

        Movement copyMovement = (Movement) super.clone();
        return copyMovement;
    }
}
