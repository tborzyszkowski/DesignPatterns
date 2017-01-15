package decorator;

public class SongBasic implements Song {

    private String content;

    public SongBasic(String content) {
        this.content = content;
    }

    @Override
    public void play() {

        System.out.println("Song : " + content);
    }

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }
}

