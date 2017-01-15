package adapter;

public class AviPlayer implements PlayerType {

    @Override
    public void play(String song) {
        System.out.println("AviPlayer is playing " + song);
    }
}

