package Factory;

/**
 * Created by K.Karkucinski on 2016-12-15.
 */
public class FactoryApple extends PhoneFactory {

    @Override
    Phone makePhone(String type) {
        if (type.equals("i6")) return new IPhone6();
        else if (type.equals("i7")) return new IPhone7();
        else return null;
    }

}
