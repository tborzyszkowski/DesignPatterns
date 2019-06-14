package watchBuilder;

public class MainApp {

    public static void main(String[] args) {

        Taskmaster taskmaster = new Taskmaster();

        WatchBuilder premiumWatchBuilder = new PremiumWatchBuilder();

        taskmaster.setWatchBuilder(premiumWatchBuilder);
        taskmaster.createWatch();

        taskmaster.getWatch().showDetails();

    }
}
