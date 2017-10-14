package protectedpackage;

import java.util.logging.Logger;

/**
 * Created by jakub on 12/7/16.
 */
public class SingletonOne extends AbstractSingletonBase {

    private static final Logger logger = Logger.getLogger(SingletonOne.class.getSimpleName());

    //allow inheriting only in package context
    protected SingletonOne() throws CannotInstantiateDirectlyException {
    }

    public static SingletonOne getInstance() {
        return (SingletonOne) getInstance(SingletonOne.class);
    }

    public void singletonOneMethod() {
        logger.info("hello from inheritance one!");
    }

}
