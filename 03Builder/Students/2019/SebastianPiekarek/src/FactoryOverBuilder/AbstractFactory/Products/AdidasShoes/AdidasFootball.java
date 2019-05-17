package FactoryOverBuilder.AbstractFactory.Products.AdidasShoes;

import FactoryOverBuilder.AbstractFactory.ComponentsFactory.ComponentsFactory;
import FactoryOverBuilder.AbstractFactory.Products.Shoes;


public class AdidasFootball extends Shoes {

    public AdidasFootball(int size, String color, String brand, ComponentsFactory componentsFactory){
        this.brand = brand;
        this.size = size;
        name = "Predator";
        price = 1199f;
        this.color = color;
        weight = 290;

        fabric = componentsFactory.createFabric();
        tie = componentsFactory.createLaces();
        sole = componentsFactory.createSole();

    }
}
