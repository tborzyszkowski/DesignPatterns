package BuilderOverFactory.FluentBuilder;

public class Product {

    protected String brand;
    protected String name;
    protected int size;
    protected String fabric;
    protected String tie;
    protected String sole;



    public void setName(String name){ this.name = name; }

    public void setSize(int size){
        this.size = size;
    }
    public void setBrand(String brand){this.brand = brand; }

    public void setFabric(String fabric){ this.fabric = fabric; }

    public void setTie(String tie){
        this.tie = tie;
    }
    public void setSole(String sole){ this.sole = sole; }

    public String toString() {
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
