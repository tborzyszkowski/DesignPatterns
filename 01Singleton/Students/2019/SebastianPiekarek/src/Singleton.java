import java.io.ObjectStreamException;
import java.io.Serializable;

public class Singleton implements Serializable {

    private static Singleton instance;
    private int x =5;
    private int y = 10;

    private Singleton(){}

    public synchronized static Singleton getInstance() {
        if(instance == null) instance = new Singleton();
        return instance;
    }

    public int getX(){
        return x;
    }

    public void setX(int number){
        x = number;
    }

    public int getY(){
        return y;
    }

    public void setY(int number){
        y = number;
    }

    private Object readResolve() throws ObjectStreamException {
        instance.x = x;
        instance.y = y;
        return instance;
    }




}
