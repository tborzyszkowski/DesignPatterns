package ClassRegistration.NoReflection.Products;

public abstract class Shoes {

    protected String brand;
    protected String name;
    protected int weight;
    protected float price;
    protected String color;

    public abstract Shoes createProduct();


    public String description(){
        return "-----------------Opis produktu-----------------" +
                "\n| " + brand + " : " + name +
                "\n| Cena: " + price + " zł" +
                "\n| Kolor: " + color +
                "\n| Waga: " + weight + "g" +
                "\n-----------------------------------------------";
    }

}
