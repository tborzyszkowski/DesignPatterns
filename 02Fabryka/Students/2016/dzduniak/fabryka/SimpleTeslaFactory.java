package fabryka;

public class SimpleTeslaFactory {
    public Car createCar(String type) {
        switch (type) {
            case "S" : return new ModelS();
            case "3" : return new Model3();
            case "X" : return new ModelX();
            default: return null;
        }
    }
}
