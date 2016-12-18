package Factory;

/**
 * Created by K.Karkucinski on 2016-12-15.
 */
public class SamsungS6 extends Phone {
    public SamsungS6(){
        price = 1800;
        displaySize =5.1;
    }
    @Override
    public String toString() {
        return "Samsung S6 cena: "+getPrice()+" Display Size: "+getDisplaySize();
    }
}
