package watchBuilder;

abstract class WatchBuilder {

    protected Watch watch;

    public Watch getWatch() {
        return watch;
    }

    public abstract void buildMovement();
    public abstract void buildGlass();
    public abstract void buildStrap();

}
