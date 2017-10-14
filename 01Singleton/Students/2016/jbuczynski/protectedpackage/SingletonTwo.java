package protectedpackage;

import java.util.logging.Logger;

/**
 * Created by jakub on 12/7/16.
 */
public class SingletonTwo extends SingletonOne {

    //allow inheriting from different package
    public SingletonTwo() throws CannotInstantiateDirectlyException {
    }

    private static final Logger logger = Logger.getLogger(SingletonTwo.class.getSimpleName());

    public static SingletonTwo getInstance() {
        return (SingletonTwo) getInstance(SingletonTwo.class);
    }

    public void singletonTwoMethod() {
        logger.info("hello from inheritance two!");
    }

}
