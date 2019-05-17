package MethodFactory.Products.AdidasShoes;

import MethodFactory.Products.Shoes;

public class AdidasRunning extends Shoes {

    public AdidasRunning(int size, String color, String brand){
        this.brand = brand;
        this.size = size;
        name = "Ultraboost";
        price = 679f;
        this.color = color;
        weight = 310;
    }
}
