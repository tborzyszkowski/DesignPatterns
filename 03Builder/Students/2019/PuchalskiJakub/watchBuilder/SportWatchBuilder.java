package watchBuilder;

public class SportWatchBuilder extends WatchBuilder {

    public SportWatchBuilder(){
        watch = new Watch("Sport fluentWatchBuilder");
    }

    @Override
    public void buildMovement() {
        watch.setMovement("Quartz");
    }

    @Override
    public void buildGlass() {
        watch.setGlass("Mineral");
    }

    @Override
    public void buildStrap() {
        watch.setStrap("Rubber");
    }
}
