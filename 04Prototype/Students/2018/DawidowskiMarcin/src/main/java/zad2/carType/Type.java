package zad2.carType;

public class Type {
    public CarType carType;
    public Transmission transmission;

    public Type(CarType carType, Transmission transmission) {
        this.carType = carType;
        this.transmission = transmission;
    }

    public Type clone() {
        return new Type(this.carType, this.transmission);
    }

    @Override
    public String toString() {
        return "{ type = " + carType.toString() +
                ", transmission = " + transmission.toString();
    }
}
