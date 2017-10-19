package singletonserialization;

import java.io.Serializable;

/**
 *
 * @author pbelke
 */
public class Singleton implements Serializable{
    
    private static Singleton instance;
    private static final long serialVersionUID = -8970497684151807777L;

    public static Singleton getInstance(){
        if(instance==null){
            instance = new Singleton();
        }
        return instance;
    }
    
    private Singleton() {
    }
    
    private Object readResolve(){
        return getInstance();
    }
}
