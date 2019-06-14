package factory;

import watchModels.Watch;
import watchModels.WatchModels;

public class Factory {

    public Watch getWatch(WatchModels watchModel){
        Watch watch = orderWatch(watchModel);
        return watch;
    }

    private Watch orderWatch(WatchModels watchModel){
        Watch watch = null;
        if (watchModel == WatchModels.C1){
            watch = new Watch(new C1Factory());
        } else if(watchModel == WatchModels.S1) {
            watch = new Watch(new S1Factory());
        } else {
            return null;
        }

        return watch;
    }

}
