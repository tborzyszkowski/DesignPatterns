package fluentWatchBuilder;

public class MainApp {

    public static void main(String[] args) {

        Watch watch = new Watch.Builder("On commision")
                .movement("mechanic")
                .glass("sapphire")
                .strap("snake leather")
                .build();

        System.out.println(watch.toString());

    }

}
