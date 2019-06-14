package abstractFactory.factories;

import abstractFactory.products.Watch;
import abstractFactory.products.WatchTypes;

public abstract class AbstractWatchFactory {

    public Watch getWatch(WatchTypes type){
        Watch watch = createWatch(type);
        return watch;
    }

    protected abstract Watch createWatch(WatchTypes type);

}
