package Singelton;

/**
 * Created by K.Karkucinski on 2016-12-16.
 */

public class Singleton {
    private static Singleton uniqueInstance;

    private Singleton(){}

    public static synchronized Singleton getUniqueInstance(){
        if (uniqueInstance == null){
            uniqueInstance = new Singleton();
        }
        return uniqueInstance;
    }
}
