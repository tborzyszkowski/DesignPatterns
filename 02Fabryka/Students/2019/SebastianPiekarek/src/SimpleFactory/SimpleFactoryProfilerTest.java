package SimpleFactory;

import SimpleFactory.Products.Shoes;
import org.junit.jupiter.api.Test;


class SimpleFactoryProfilerTest {

    @Test
    void TestSimpleFactory(){
        SimpleFactory simpleFactory = SimpleFactory.getInstance();
        Shoes shoes;

        shoes = simpleFactory.createShoes("Koszykówka");
        System.out.println(shoes.description());

        shoes = simpleFactory.createShoes("Bieganie");
        System.out.println(shoes.description());

        shoes = simpleFactory.createShoes("Piłka nożna");
        System.out.println(shoes.description());

    }
}