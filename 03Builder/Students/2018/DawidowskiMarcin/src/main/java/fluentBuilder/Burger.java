package fluentBuilder;

public class Burger {
    public String cutlet;
    public String loaf;
    public boolean cheese;
    public boolean tomato;
    public int price;

    public void setCutlet(String cutlet) {
        this.cutlet = cutlet;
    }

    public void setLoaf(String loaf) {
        this.loaf= loaf;
    }

    public void setCheese(Boolean cheese) {
        this.cheese= cheese;
    }

    public void setTomato(Boolean tomato) {
        this.tomato = tomato;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    @Override
    public String toString() {
        return  "Cutlet = " + cutlet +
                ", loaf = " + loaf +
                ", cheese = " + cheese +
                ", tomato = " + tomato +
                ", price = " + price;
    }
}
