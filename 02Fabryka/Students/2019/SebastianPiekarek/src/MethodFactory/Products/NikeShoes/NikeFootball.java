package MethodFactory.Products.NikeShoes;

import MethodFactory.Products.Shoes;

public class NikeFootball extends Shoes {

    public NikeFootball(int size, String color, String brand){
        this.brand = brand;
        this.size = size;
        name = "Phantom Venom";
        price = 1149;
        this.color = color;
        weight = 278;
    }
}
