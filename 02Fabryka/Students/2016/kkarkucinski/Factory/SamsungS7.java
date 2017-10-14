package Factory;

/**
 * Created by K.Karkucinski on 2016-12-15.
 */
public class SamsungS7 extends Phone{
    public SamsungS7(){
        price = 2200;
        displaySize =5.3;
    }

    @Override
    public String toString() {
        return "Samsung S7 cena: "+getPrice()+" Display Size: "+getDisplaySize();
    }
}