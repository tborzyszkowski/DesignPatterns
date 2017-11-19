package pl.mhallman.java.singletonPattern.singleton;

import org.apache.log4j.Logger;

public class ThreadSafeSingletone {

    static Logger LOG = Logger.getRootLogger();

    private static ThreadSafeSingletone instance = null;

    protected ThreadSafeSingletone() {}

    public synchronized static ThreadSafeSingletone getInstance() {
        LOG.info(">>> ThreadSafeSingletone :: getInstance() - starts ");
        if(instance == null) {
            LOG.info("Checking instance :: first time");
            synchronized (ThreadSafeSingletone.class) {
                if(instance == null) {
                    LOG.info("Checking instance :: second time");
                    instance = new ThreadSafeSingletone();
                }
            }
        }
        LOG.info(">>> ThreadSafeSingletone :: getInstance() - ends ");
        return instance;
    }
}
