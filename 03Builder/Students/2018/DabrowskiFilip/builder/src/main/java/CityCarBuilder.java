public class CityCarBuilder extends CarBuilder {

    public void buildWheels() {
        this.car.wheels = "14' city wheels";
    }

    public void buildEngine() {
        this.car.engineCapacity = "1.3";
    }

    public void buildBody() {
        this.car.bodyType = "14' city wheels";
    }
}
