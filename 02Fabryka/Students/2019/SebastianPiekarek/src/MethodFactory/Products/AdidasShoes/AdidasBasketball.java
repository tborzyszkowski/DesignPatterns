package MethodFactory.Products.AdidasShoes;

import MethodFactory.Products.Shoes;

public class AdidasBasketball extends Shoes {

    public AdidasBasketball(int size, String color, String brand){
        this.brand = brand;
        this.size = size;
        name = "T-MAC Millenium";
        price = 679f;
        this.color = color;
        weight = 350;

    }
}
