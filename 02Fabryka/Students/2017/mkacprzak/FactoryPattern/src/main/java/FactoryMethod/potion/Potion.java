package FactoryMethod.potion;

public abstract class Potion {

    protected String name;
    protected String description;
    protected int size;

    public String getName() {
        return name;
    }


    public int getSize() {
        return size;
    }

    public String getDescription() {
        return description;
    }


    public void addMagic()
    {
        System.out.println("Adding some magic!");
    }

    public void setSize(int size) {
        this.size = size;
    }

    @Override
    public String toString() {
        return name + " - " + description + "Size " + size;
    }
}