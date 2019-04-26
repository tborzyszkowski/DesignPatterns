package FactoryOverBuilder.AbstractFactory;


import FactoryOverBuilder.AbstractFactory.Factories.AdidasFactory;
import FactoryOverBuilder.AbstractFactory.Factories.NikeFactory;
import FactoryOverBuilder.AbstractFactory.Products.Shoes;

public class TestAbstractFactory {

    public static void main(String[] args) {
        AdidasFactory adidasFactory = AdidasFactory.getAdidasFactory();
        NikeFactory nikeFactory = NikeFactory.getNikeFactory();

        Shoes shoes;

        shoes = nikeFactory.orderShoes("Koszykówka", 47, "biały");
        System.out.println(shoes.description());

        shoes = adidasFactory.orderShoes("Bieganie", 47, "czerwony");
        System.out.println(shoes.description());

        shoes = adidasFactory.orderShoes("Piłka nożna", 47, "czarny");
        System.out.println(shoes.description());

    }
}
