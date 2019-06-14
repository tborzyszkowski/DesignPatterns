package DeepPrototype;

import java.util.HashMap;
import java.util.Hashtable;

public class PrototypeManager {

    Hashtable<WatchTypes, Watch> watchHashMap = new Hashtable<>();

    public Watch getWatch(WatchTypes watchType) throws CloneNotSupportedException {
        return (Watch) watchHashMap.get(watchType).clone();
    }

    public void loadWatches(){
        watchHashMap.put(WatchTypes.PremiumWatch, new Watch(new Movement("Automatic"), new Strap("Leather", new Clasp("metal")),
                new Glass("sapphire")));
        watchHashMap.put(WatchTypes.ClassicWatch, new Watch(new Movement("Automatic"), new Strap("Rubber", new Clasp("plastic")),
                new Glass("hesalite")));
        watchHashMap.put(WatchTypes.SportWatch, new Watch(new Movement("Quartz"), new Strap("Metal", new Clasp("metal")),
                new Glass("mineral")));
    }


}
