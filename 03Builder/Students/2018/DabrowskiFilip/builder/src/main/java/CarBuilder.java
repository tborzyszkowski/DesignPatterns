public abstract class CarBuilder {

    protected CarBuilder() {
        this.car = new Car();
    }

    protected Car car;

    public abstract void buildWheels();

    public abstract void buildEngine();

    public abstract void buildBody();

    public Car getCar() {
        return car;
    }


}
