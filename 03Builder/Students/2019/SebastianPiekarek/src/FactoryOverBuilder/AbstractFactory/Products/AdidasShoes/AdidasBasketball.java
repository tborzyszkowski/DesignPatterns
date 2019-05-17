package FactoryOverBuilder.AbstractFactory.Products.AdidasShoes;


import FactoryOverBuilder.AbstractFactory.ComponentsFactory.ComponentsFactory;
import FactoryOverBuilder.AbstractFactory.Products.Shoes;

public class AdidasBasketball extends Shoes {

    public AdidasBasketball(int size, String color, String brand, ComponentsFactory componentsFactory){
        this.brand = brand;
        this.size = size;
        name = "T-MAC Millenium";
        price = 679f;
        this.color = color;
        weight = 350;
        fabric = componentsFactory.createFabric();
        tie = componentsFactory.createLaces();
        sole = componentsFactory.createSole();

    }
}
