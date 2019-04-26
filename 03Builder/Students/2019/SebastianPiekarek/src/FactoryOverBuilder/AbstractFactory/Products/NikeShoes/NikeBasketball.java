package FactoryOverBuilder.AbstractFactory.Products.NikeShoes;


import FactoryOverBuilder.AbstractFactory.ComponentsFactory.ComponentsFactory;
import FactoryOverBuilder.AbstractFactory.Products.Shoes;

public class NikeBasketball extends Shoes {

    public NikeBasketball(int size, String color, String brand, ComponentsFactory componentsFactory){
        this.brand = brand;
        this.size = size;
        name = "Air Jordan";
        price = 849f;
        this.color = color;
        weight = 259;
        fabric = componentsFactory.createFabric();
        tie = componentsFactory.createLaces();
        sole = componentsFactory.createSole();

    }
}
