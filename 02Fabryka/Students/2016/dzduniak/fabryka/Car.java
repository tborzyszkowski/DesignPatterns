package fabryka;

public abstract class Car {
    public abstract String getModelName();
    public abstract double getMaxSpeed();

    @Override
    public String toString() {
        return "Car { Model = " + getModelName() + ", MaxSpeed = " + getMaxSpeed() + " kph }";
    }
}
