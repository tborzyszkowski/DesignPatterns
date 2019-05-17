package MethodFactory;

import MethodFactory.Factories.AdidasFactory;
import MethodFactory.Factories.NikeFactory;
import MethodFactory.Products.Shoes;
import org.junit.jupiter.api.Test;


class MethodFactoryOrderTest {

    @Test
    void testMethodFactoryNike(){
        NikeFactory nikeFactory = NikeFactory.getNikeFactory();
        Shoes shoes;

        shoes = nikeFactory.orderShoes("Bieganie", 47, "czarny");
        System.out.println(shoes.description());

        shoes = nikeFactory.orderShoes("Koszykówka", 47, "czarny");
        System.out.println(shoes.description());

        shoes = nikeFactory.orderShoes("Piłka nożna", 47, "czarny");
        System.out.println(shoes.description());

        AdidasFactory adidasFactory = AdidasFactory.getAdidasFactory();

        shoes = adidasFactory.orderShoes("Bieganie", 47, "czarny");
        System.out.println(shoes.description());

        shoes = adidasFactory.orderShoes("Koszykówka", 47, "czarny");
        System.out.println(shoes.description());

        shoes = adidasFactory.orderShoes("Piłka nożna", 47, "czarny");
        System.out.println(shoes.description());

    }

}