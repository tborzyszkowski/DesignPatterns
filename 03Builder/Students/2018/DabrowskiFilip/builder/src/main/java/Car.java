public class Car {

    public String wheels;

    public String engineCapacity;

    public String bodyType;

    public Car() {
    }

    @Override
    public String toString() {
        return "Car{" +
                "wheels='" + wheels + '\'' +
                ", engineCapacity='" + engineCapacity + '\'' +
                ", bodyType='" + bodyType + '\'' +
                '}';
    }
}
