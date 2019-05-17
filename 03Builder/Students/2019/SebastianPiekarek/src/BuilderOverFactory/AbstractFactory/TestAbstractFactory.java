package BuilderOverFactory.AbstractFactory;


import BuilderOverFactory.AbstractFactory.Factories.NikeFactory;
import BuilderOverFactory.AbstractFactory.Products.Shoes;

public class TestAbstractFactory {

    public static void main(String[] args) {
        NikeFactory nikeFactory = NikeFactory.getNikeFactory();

        Shoes shoes;

        shoes = nikeFactory.orderShoes("Piłka nożna", 47, "czerwony", 1200);
        System.out.println(shoes.description());

    }
}
