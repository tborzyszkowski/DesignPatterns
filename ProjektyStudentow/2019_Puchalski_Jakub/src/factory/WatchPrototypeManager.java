package factory;

import watchModels.Watch;
import watchModels.WatchModels;

import java.util.Hashtable;

public class WatchPrototypeManager {

    public Hashtable<WatchModels, Watch> watchHashMap = new Hashtable<>();

    public Watch getWatch(WatchModels watchType) throws CloneNotSupportedException {
        return (Watch) watchHashMap.get(watchType).clone();
    }

    public void loadWatches(){
        Factory factory = new Factory();
        for (WatchModels wm: WatchModels.values()) {
            watchHashMap.put(wm, factory.getWatch(wm));
        }
    }

}
