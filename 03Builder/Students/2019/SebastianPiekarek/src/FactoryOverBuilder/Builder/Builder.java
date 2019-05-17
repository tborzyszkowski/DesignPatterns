package FactoryOverBuilder.Builder;

public abstract class Builder {

    protected Product shoes;

    public void newProduct(){
        shoes = new Product();
    }

    public Product getShoes(){
        return shoes;
    }

    abstract void buildShoes();
    abstract void setName();
    abstract  void setColor(String color);
    abstract void setPrice();
    abstract void setSize(int size);


}
