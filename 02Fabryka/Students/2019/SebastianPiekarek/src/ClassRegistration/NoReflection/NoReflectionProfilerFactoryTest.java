package ClassRegistration.NoReflection;

import ClassRegistration.NoReflection.Products.Shoes;
import org.junit.jupiter.api.Test;

class NoReflectionProfilerFactoryTest {

    @Test
    void TestNoReflectionFactory() {
        Shoes shoes;
        NoReflectionFactory noReflectionFactory = NoReflectionFactory.getNoReflectionFactory();

        shoes = noReflectionFactory.createShoes("Bieganie");
        System.out.println(shoes.description());

        shoes = noReflectionFactory.createShoes("Koszykówka");
        System.out.println(shoes.description());

        shoes = noReflectionFactory.createShoes("Piłka nożna");
        System.out.println(shoes.description());


    }

}