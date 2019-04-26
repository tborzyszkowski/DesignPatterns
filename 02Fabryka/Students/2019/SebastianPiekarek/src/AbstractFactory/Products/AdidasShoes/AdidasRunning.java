package AbstractFactory.Products.AdidasShoes;


import AbstractFactory.ComponentsFactory.ComponentsFactory;
import AbstractFactory.Products.Shoes;

public class AdidasRunning extends Shoes {

    public AdidasRunning(int size, String color, String brand, ComponentsFactory componentsFactory){
        this.brand = brand;
        this.size = size;
        name = "Ultraboost";
        price = 679f;
        this.color = color;
        weight = 310;
        fabric = componentsFactory.createFabric();
        tie = componentsFactory.createTie();
        sole = componentsFactory.createSole();

    }
}
