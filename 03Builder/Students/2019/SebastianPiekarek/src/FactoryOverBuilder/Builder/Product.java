package FactoryOverBuilder.Builder;

public class Product {

    protected String brand;
    protected String name;
    protected int size;
    protected float price;
    protected String color;
    protected int weight;

    protected String fabric;
    protected String tie;
    protected String sole;


    public String toString() {
        return "----------------- Opis produktu -----------------" +
                "\n| " + brand + " : " + name +
                "\n| Rozmiar: " + size +
                "\n| Cena: " + price + " zł" +
                "\n| Kolor: " + color +
                "\n| Waga: " + weight + "g" +
                "\n--------------------- Cechy ---------------------" +
                "\nMateriał : " + fabric +
                "\nWiązanie : " + tie +
                "\nPodeszwa : " + sole +
                "\n-------------------------------------------------\n";
    }
}
