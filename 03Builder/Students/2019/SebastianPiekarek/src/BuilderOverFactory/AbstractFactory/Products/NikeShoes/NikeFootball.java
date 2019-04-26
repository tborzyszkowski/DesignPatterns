package BuilderOverFactory.AbstractFactory.Products.NikeShoes;


import BuilderOverFactory.AbstractFactory.ComponentsFactory.ComponentsFactory;
import BuilderOverFactory.AbstractFactory.Products.Shoes;

public class NikeFootball extends Shoes {

    int[] sizes = new int[]{42,43,44,45,46,47,48,49};

    public NikeFootball(String brand, int size, String color, int price, ComponentsFactory componentsFactory){
        this.brand = brand;
        name = "Phantom Venom";

        for (int available : sizes) {
            if (size == available) this.size = size;
        }
        fabric = componentsFactory.createFabric(color);
        tie = componentsFactory.createLaces(price);
        sole = componentsFactory.createSole(price);

    }
}
