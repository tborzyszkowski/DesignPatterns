package decorator;

public class SongBasicDecorator implements Song {

    private SongBasic songBasic;

    public SongBasicDecorator(SongBasic songBasic) {
        this.songBasic = songBasic;
    }

    @Override
    public void play() {
        System.out.println("Decorator is doing sth before ...");
        songBasic.play();
        System.out.println("Decorator is doing sth after ...");
    }
}

