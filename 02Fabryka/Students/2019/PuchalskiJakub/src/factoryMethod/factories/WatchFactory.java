package factoryMethod.factories;

import factoryMethod.products.Watch;
import factoryMethod.products.WatchTypes;

public abstract class WatchFactory {

    public Watch getWatch(WatchTypes type){
        Watch watch = createWatch(type);
        return watch;
    }

    protected abstract Watch createWatch(WatchTypes type);
}
