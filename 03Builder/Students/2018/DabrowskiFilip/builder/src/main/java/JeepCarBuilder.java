public class JeepCarBuilder extends CarBuilder {

    public void buildWheels() {
        this.car.wheels = "23' off-road wheels";
    }

    public void buildEngine() {
        this.car.engineCapacity = "2.0";
    }

    public void buildBody() {
        this.car.bodyType = "off-road body";
    }
}
