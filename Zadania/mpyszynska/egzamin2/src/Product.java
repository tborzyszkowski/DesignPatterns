
public class Product implements Visitor {

    public String name;
    public int cena;

    @Override
    public String toString() {
        return "Produkt{" +
                "name='" + name + '\'' +
                ", cena='" + cena + '\'' +
                '}';
    }

    public Product(){

    }

    public void visit(Raport visitable) {
        System.out.println("Dodany produkt");
    }



}
