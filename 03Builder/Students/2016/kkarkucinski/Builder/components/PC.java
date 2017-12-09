package Builder.components;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public class PC {
    private CPU cpu;
    private VideoCard videoCard;
    private MotherBoard motherBoard;


    public CPU getCpu() {
        return cpu;
    }

    public void setCpu(CPU cpu) {
        this.cpu = cpu;
    }

    public VideoCard getVideoCard() {
        return videoCard;
    }

    public void setVideoCard(VideoCard videoCard) {
        this.videoCard = videoCard;
    }

    public MotherBoard getMotherBoard() {
        return motherBoard;
    }

    public void setMotherBoard(MotherBoard motherBoard) {
        this.motherBoard = motherBoard;
    }

    @Override
    public String toString() {
        return "PC{" +
                "cpu=" + cpu +
                ", videoCard=" + videoCard +
                ", motherBoard=" + motherBoard +
                '}';
    }
}


