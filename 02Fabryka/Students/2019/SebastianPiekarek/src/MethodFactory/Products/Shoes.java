package MethodFactory.Products;

public abstract class Shoes {

    protected String brand;
    protected String name;
    protected int size;
    protected float price;
    protected String color;
    protected int weight;


    public String description(){
        return "-----------------Opis produktu-----------------" +
                "\n| " + brand + " : " + name +
                "\n| Rozmiar: " + size +
                "\n| Cena: " + price + " zł" +
                "\n| Kolor: " + color +
                "\n| Waga: " + weight + "g" +
                "\n-----------------------------------------------\n";
    }
}

