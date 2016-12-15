package protectedpackage;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.concurrent.locks.ReentrantLock;
import java.util.logging.Logger;

/**
 *
 */
public abstract class AbstractSingletonBase {

    private static final Logger logger = Logger.getLogger(AbstractSingletonBase.class.getSimpleName());

    private static final Map singletonRegistry = new HashMap();

    private static ReentrantLock lock = new ReentrantLock();

    private static SingletonFactory singletonFactory = new SingletonFactory();

    public AbstractSingletonBase() throws CannotInstantiateDirectlyException {
        long startTime = System.currentTimeMillis();
        //allow only registry(SingletonFactory) constructor invocation
        if (!Arrays.stream(CallerResolver.CALLER_RESOLVER.getClassContext()).anyMatch(clazz -> clazz.getSimpleName().equals(SingletonFactory.class.getSimpleName())) &&
                AbstractSingletonBase.getInstance(this.getClass()) != null) {
            throw new CannotInstantiateDirectlyException(String.format("Cannot perform direct creation attempt. Use %s getInstance method to obtain instance.", this.getClass()));
        }
        long stopTime = System.currentTimeMillis();
        long elapsedTime = stopTime - startTime;
        logger.info("performance cost of class check: " + elapsedTime);
    }

    public static final AbstractSingletonBase getInstance(Class clazz) {
        lock.lock();
        try {
            AbstractSingletonBase instance = (AbstractSingletonBase) singletonRegistry.get(clazz);
            if (instance == null) {
                if (!AbstractSingletonBase.class.isAssignableFrom(clazz))
                    throw new IllegalArgumentException("Class " + clazz.getName() + " does not inherit from protectedpackage.AbstractSingletonBase.");
                try {
                    instance = singletonFactory.constructInstance(clazz);
                } catch (Exception ex) {
                    logger.severe("Can not create instance for " + clazz.getName() + ": " + ex.getMessage());
                }
                if (instance != null) {
                    singletonRegistry.put(clazz, instance);
                    logger.info("New registered inheritance " + clazz.getName());
                } else
                    logger.severe("Could not register instance " + clazz.getName() + ".");
            }
            return instance;
        } finally {
            lock.unlock();
        }

    }
    private static class SingletonFactory {
        public  AbstractSingletonBase constructInstance(Class clazz) throws IllegalAccessException, InstantiationException {
            return (AbstractSingletonBase) clazz.newInstance();
        }
    }

    private static final class CallerResolver extends SecurityManager {
        private static final CallerResolver CALLER_RESOLVER = new CallerResolver();
        protected Class[] getClassContext() {
            return super.getClassContext();
        }
    }
}
