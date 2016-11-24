package fabryka;

public class ModelS extends Car {
    @Override
    public String getModelName() {
        return "S";
    }

    @Override
    public double getMaxSpeed() {
        return 100;
    }
}
