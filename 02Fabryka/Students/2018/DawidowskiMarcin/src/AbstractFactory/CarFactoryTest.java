package AbstractFactory;

public class CarFactoryTest {
    public static void main(String[] args) {
        testAbstractCarFactory();
    }

    private static void testAbstractCarFactory() {
        Car nissan = CarFactory.getCar(new NissanFactory("Nissan", "GT-R", "Coupe", "Gasoline", 56000));
        System.out.println("Nissan Abstract:: " + nissan);
        Car kia = CarFactory.getCar(new NissanFactory("KIA", "Stinger", "Sedan", "Diesel", 156000));
        System.out.println("KIA Abstract:: " + kia);
    }
}
