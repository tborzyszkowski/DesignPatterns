package FactoryOverBuilder.Builder;

public class RunningShoesBuilder extends Builder {


    @Override
    public void buildShoes() {
        shoes.fabric = "Syntetyczno-tekstylna cholewka";
        shoes.sole = "Obniżona podeszwa środkowa";
        shoes.tie = "Sznurowadła";
        shoes.weight = 254;
    }

    @Override
    public void setName() {
        shoes.brand = "NIKE";
        shoes.name = "Air Zoom Pegasus";
    }

    @Override
    public void setColor(String color) {
        shoes.color = color;
    }

    @Override
    public void setPrice() {
        shoes.price = 499f;
    }

    @Override
    public void setSize(int size) {
        shoes.size = size;
    }

}
