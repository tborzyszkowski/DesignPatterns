package zad2.engine;

public class Engine {
    public EngineType engineType;
    public int horsepower;

    public Engine(EngineType engineType, int horsepower) {
        this.engineType = engineType;
        this.horsepower = horsepower ;
    }

    public Engine clone() {
        return new Engine(this.engineType, this.horsepower);
    }

    @Override
    public String toString() {
        return "{ type = " + engineType.toString() +
                ", horsepower = " + horsepower +
                " }";
    }
}
