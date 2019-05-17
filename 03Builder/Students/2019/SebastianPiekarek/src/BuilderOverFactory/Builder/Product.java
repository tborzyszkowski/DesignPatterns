package BuilderOverFactory.Builder;

public class Product {

    protected String brand;
    protected String name;
    protected int size;


    protected String fabric;
    protected String tie;
    protected String sole;


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
