package adapter;

public class MediaAdapter implements MusicPlayer {

    private static final String MP3 = "mp3";
    private static final String AVI = "avi";
    private PlayerType mp3 = new Mp3Player();
    private PlayerType avi = new AviPlayer();


    @Override
    public void playMusic(String mimeType, String media) {
        if (mimeType.equalsIgnoreCase(MP3)) {
            mp3.play(media);
        } else if (mimeType.equalsIgnoreCase(AVI)) {
            avi.play(media);
        } else {
            throw new RuntimeException("Unsupported type of mimeType");
        }

    }
}

