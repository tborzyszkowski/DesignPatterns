package Factory;

/**
 * Created by K.Karkucinski on 2016-12-15.
 */
public class FactorySamsung extends PhoneFactory {

    @Override
    Phone makePhone(String type) {
        if (type.equals("s6")) return new SamsungS6();
        else if (type.equals("s7")) return new SamsungS7();
        else return null;
    }
}
