package FactoryMethod;

public class CarTest {
    public static void main(String[] args){
        CarFactoryMethod nissan = new NissanFactory();
        Car car = nissan.getCar("350Z");
        System.out.println(car.toString());
        car = nissan.getCar("GT-R");
        System.out.println(car.toString());

        CarFactoryMethod kia = new KIAFactory();
        car = kia.getCar("Stinger");
        System.out.println(car.toString());
        car = kia.getCar("Ceed");
        System.out.println(car.toString());
    }
}
