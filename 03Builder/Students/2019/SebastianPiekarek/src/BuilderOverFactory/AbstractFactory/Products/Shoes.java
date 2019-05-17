package BuilderOverFactory.AbstractFactory.Products;

import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Fabric.Fabric;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Laces.Tie;
import BuilderOverFactory.AbstractFactory.ComponentsFactory.Components.Sole.Sole;

public abstract class Shoes {

    protected String brand;
    protected String name;
    protected int size;

    protected Fabric fabric;
    protected Tie tie;
    protected Sole sole;



    public String description() {
        return "----------------- Opis produktu -----------------" +
                "\n| " + brand + " : " + name +
                "\nRozmiar: " + size +
                "\n--------------------- Cechy ---------------------" +
                "\nMateriał : " + fabric +
                "\nWiązanie : " + tie +
                "\nPodeszwa : " + sole +
                "\n-------------------------------------------------\n";
    }
}
