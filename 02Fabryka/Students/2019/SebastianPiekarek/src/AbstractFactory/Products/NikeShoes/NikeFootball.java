package AbstractFactory.Products.NikeShoes;


import AbstractFactory.ComponentsFactory.ComponentsFactory;
import AbstractFactory.Products.Shoes;

public class NikeFootball extends Shoes {

    public NikeFootball(int size, String color, String brand, ComponentsFactory componentsFactory){
        this.brand = brand;
        this.size = size;
        name = "Phantom Venom";
        price = 1149;
        this.color = color;
        weight = 278;
        fabric = componentsFactory.createFabric();
        tie = componentsFactory.createTie();
        sole = componentsFactory.createSole();

    }
}
