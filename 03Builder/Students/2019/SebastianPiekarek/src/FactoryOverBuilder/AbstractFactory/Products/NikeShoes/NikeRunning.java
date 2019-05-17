package FactoryOverBuilder.AbstractFactory.Products.NikeShoes;


import FactoryOverBuilder.AbstractFactory.ComponentsFactory.ComponentsFactory;
import FactoryOverBuilder.AbstractFactory.Products.Shoes;

public class NikeRunning extends Shoes {

    public NikeRunning(int size, String color, String brand, ComponentsFactory componentsFactory){
        this.brand = brand;
        this.size = size;
        name = "Air Zoom Pegasus";
        price = 499f;
        this.color = color;
        weight = 254;
        fabric = componentsFactory.createFabric();
        tie = componentsFactory.createLaces();
        sole = componentsFactory.createSole();

    }
}
