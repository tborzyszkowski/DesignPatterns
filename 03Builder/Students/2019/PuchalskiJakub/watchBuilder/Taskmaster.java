package watchBuilder;

public class Taskmaster {
    private WatchBuilder watchBuilder;

    public void setWatchBuilder(WatchBuilder watchBuilder){
        this.watchBuilder = watchBuilder;
    }

    public void createWatch(){
        watchBuilder.buildMovement();
        watchBuilder.buildGlass();
        watchBuilder.buildStrap();
    }

    public Watch getWatch() {
        return watchBuilder.getWatch();
    }
}
