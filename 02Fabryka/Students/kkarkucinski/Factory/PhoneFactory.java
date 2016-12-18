package Factory;

/**
 * Created by K.Karkucinski on 2016-12-15.
 */
public abstract class PhoneFactory {
    public Phone orderPhone(String type){
        Phone phone;
        phone = makePhone(type);
        phone.wrapping();
        phone.sending();
        return phone;
    }
    abstract Phone makePhone(String type);
}
