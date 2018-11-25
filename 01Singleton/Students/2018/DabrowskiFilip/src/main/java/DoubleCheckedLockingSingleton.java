import java.io.Serializable;

public class DoubleCheckedLockingSingleton implements Serializable {

    private static DoubleCheckedLockingSingleton synchronizedSingletonInstance;

    protected DoubleCheckedLockingSingleton (){
    }

    public static DoubleCheckedLockingSingleton getInstance() {
        if (synchronizedSingletonInstance == null) {
            // double checked locking
            synchronized (DoubleCheckedLockingSingleton.class) {
                if(synchronizedSingletonInstance == null){
                    synchronizedSingletonInstance = new DoubleCheckedLockingSingleton();
                }
            }
        }
        return synchronizedSingletonInstance;
    }

    @Override
    public int hashCode() {
        return super.hashCode();
    }

    @Override
    public boolean equals(Object obj) {
        return super.equals(obj);
    }
}

