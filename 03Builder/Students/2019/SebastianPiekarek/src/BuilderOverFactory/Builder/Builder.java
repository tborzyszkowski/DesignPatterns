package BuilderOverFactory.Builder;

public abstract class Builder {

    protected Product shoes;

    public void newProduct(){
        shoes = new Product();
    }

    public Product getShoes(){
        return shoes;
    }

    abstract void setSize(int size);
    abstract void setFabric(String color);
    abstract void setSole(int price);
    abstract void setTie(int price);
    abstract void setName();



}
