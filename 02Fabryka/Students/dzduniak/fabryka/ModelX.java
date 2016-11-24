package fabryka;

public class ModelX extends Car {
    @Override
    public String getModelName() {
        return "X";
    }

    @Override
    public double getMaxSpeed() {
        return 120;
    }
}
