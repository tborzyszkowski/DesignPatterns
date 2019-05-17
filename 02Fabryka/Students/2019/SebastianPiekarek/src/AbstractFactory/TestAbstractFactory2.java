package AbstractFactory;

import AbstractFactory.Factories.AdidasFactory;
import AbstractFactory.Factories.NikeFactory;
import AbstractFactory.Products.Shoes;
import org.junit.jupiter.api.Test;


class TestAbstractFactory2 {

    @Test
    void testMethodFactoryNike(){
        AdidasFactory adidasFactory = AdidasFactory.getAdidasFactory();
        NikeFactory nikeFactory = NikeFactory.getNikeFactory();

        Shoes shoes;

        shoes = nikeFactory.orderShoes("Koszykówka", 47, "biały");
        System.out.println(shoes.description());

        shoes = nikeFactory.orderShoes("Bieganie", 47, "czerwony");
        System.out.println(shoes.description());

        shoes = nikeFactory.orderShoes("Piłka nożna", 47, "czarny");
        System.out.println(shoes.description());

        shoes = adidasFactory.orderShoes("Koszykówka", 47, "biały");
        System.out.println(shoes.description());

        shoes = adidasFactory.orderShoes("Bieganie", 47, "czerwony");
        System.out.println(shoes.description());

        shoes = adidasFactory.orderShoes("Piłka nożna", 47, "czarny");
        System.out.println(shoes.description());

    }

}