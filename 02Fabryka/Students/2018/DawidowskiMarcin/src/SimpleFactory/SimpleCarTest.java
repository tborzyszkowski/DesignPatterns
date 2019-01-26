package SimpleFactory;

public class SimpleCarTest {
    public static void main(String[] args) {

        Car vehicle1 = SimpleCarFactory.getCar("KIA");
        Car vehicle2 = SimpleCarFactory.getCar("BMW");
        Car vehicle3 = SimpleCarFactory.getCar("Nissan");
        Car vehicle4 = SimpleCarFactory.getCar("Aston Martin");

        System.out.println(vehicle1.toString());
        System.out.println(vehicle2.toString());
        System.out.println(vehicle3.toString());
        System.out.println(vehicle4.toString());
    }

}
