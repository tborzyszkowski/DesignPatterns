package FactoryOverBuilder.Builder;


public class Director {
    private Builder builder;

    public void setBuilder(Builder builder){
        this.builder = builder;
    }

    public void Construct( int size,  String color) {
        builder.newProduct();
        builder.buildShoes();
        builder.setName();
        builder.setColor(color);
        builder.setPrice();
        builder.setSize(size);
    }
}
