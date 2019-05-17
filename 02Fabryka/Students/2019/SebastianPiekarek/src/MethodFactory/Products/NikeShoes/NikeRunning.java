package MethodFactory.Products.NikeShoes;

import MethodFactory.Products.Shoes;

public class NikeRunning extends Shoes {

    public NikeRunning(int size, String color, String brand){
        this.brand = brand;
        this.size = size;
        name = "Air Zoom Pegasus";
        price = 499f;
        this.color = color;
        weight = 254;

    }
}
