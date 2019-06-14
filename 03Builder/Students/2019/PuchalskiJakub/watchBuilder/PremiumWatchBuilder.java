package watchBuilder;

public class PremiumWatchBuilder extends WatchBuilder {

    public PremiumWatchBuilder(){
        watch = new Watch("Premium Watch");
    }

    @Override
    public void buildMovement() {
        watch.setMovement("Automatic");
    }

    @Override
    public void buildGlass() {
        watch.setGlass("Saphire");
    }

    @Override
    public void buildStrap() {
        watch.setStrap("Leather");
    }
}
