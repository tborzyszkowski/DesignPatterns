package Factory;

/**
 * Created by K.Karkucinski on 2016-12-15.
 */
public class IPhone7 extends Phone{
        public IPhone7(){
            price = 2800;
            displaySize =4.9;
        }
    @Override
    public String toString() {
        return "IPhon 7 cena: "+getPrice()+" Display Size: "+getDisplaySize();
    }
}


