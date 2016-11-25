package task1;

public class Main {

    public static void main(String[] args) {
        CarFactory carFactory = new CarFactory();

        Car audi = carFactory.getCar("audi");
        System.out.println(audi.getName());

        Car bmw = carFactory.getCar("bmw");
        System.out.println(bmw.getName());

    }


}

