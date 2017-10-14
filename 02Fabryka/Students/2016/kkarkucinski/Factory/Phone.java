package Factory;

/**
 * Created by K.Karkucinski on 2016-12-15.
 */
public abstract class Phone {
    int price;
    double displaySize;

    void wrapping(){
        System.out.println("Wraping new Phone");
    }
    void sending(){
        System.out.println("Sending new Phone\n");
    }

    public int getPrice() {
        return price;
    }

    public double getDisplaySize() {
        return displaySize;
    }

}


