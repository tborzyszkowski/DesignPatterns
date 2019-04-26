package MethodFactory.Products.AdidasShoes;

import MethodFactory.Products.Shoes;

public class AdidasFootball extends Shoes {

    public AdidasFootball(int size, String color, String brand){
        this.brand = brand;
        this.size = size;
        name = "Predator";
        price = 1199f;
        this.color = color;
        weight = 290;
    }
}
