package watchBuilder;

public class CasualWatchBuilder extends WatchBuilder {

    public CasualWatchBuilder(){
        watch = new Watch("Casual fluentWatchBuilder");
    }

    @Override
    public void buildMovement() {
        watch.setMovement("Quartz");
    }

    @Override
    public void buildGlass() {
        watch.setGlass("Hesalite");
    }

    @Override
    public void buildStrap() {
        watch.setStrap("Metal");
    }
}
