package Factory;

/**
 * Created by K.Karkucinski on 2016-12-15.
 */
public class IPhone6 extends Phone{
    public IPhone6(){
        price = 1900;
        displaySize =4.7;
    }
    @Override
    public String toString() {
        return "IPhon 6 cena: "+getPrice()+" Display Size: "+getDisplaySize();
    }
}
