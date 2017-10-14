package Factory;

/**
 * Created by K.Karkucinski on 2016-12-15.
 */
public class Test {
    public static void main(String[]args){
    FactoryApple apple = new FactoryApple();
    FactorySamsung samsung = new FactorySamsung();

    Phone one = apple.orderPhone("i6");
    Phone second = samsung.orderPhone("s7");

        System.out.println(one.toString());
        System.out.println(second.toString());


    }
}
