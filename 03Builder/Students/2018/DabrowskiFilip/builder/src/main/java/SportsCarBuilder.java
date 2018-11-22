public class SportsCarBuilder extends CarBuilder {

    public SportsCarBuilder() {
        super();
    }

    public void buildWheels() {
        this.car.wheels = "Sports 21' wheels";
    }

    public void buildEngine() {
        this.car.engineCapacity = "4.0";
    }

    public void buildBody() {
        this.car.bodyType = "sport body";
    }

}
