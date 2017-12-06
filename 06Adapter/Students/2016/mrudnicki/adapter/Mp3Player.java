package adapter;

public class Mp3Player implements PlayerType {

    @Override
    public void play(String song) {
        System.out.println("Mp3Player is playing : " + song);
    }
}

