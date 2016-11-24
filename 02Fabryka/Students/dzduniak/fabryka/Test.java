package fabryka;

/**
 * Fabryka która zamiast wykorzystania do tworzenia instancji refleksji
 * (wywołująca poprzez refleksję pusty konstruktor i wymagająca przez to jego istnienia,
 * bez możliwości sprawdzenia tego warunku podczas kompilacji)
 * pobiera jako argument przy rejestracji funkcję która tworzy instancje.
 */
public class Test {
    public static void main(String[] args) {
        CarFactory factory = new CarFactory();
        factory.register("S", ModelS::new);
        factory.register("3", Model3::new);
        factory.register("X", ModelX::new);
        System.out.println(factory.createCar("S"));
        System.out.println(factory.createCar("3"));
        System.out.println(factory.createCar("X"));
    }
}
