package Builder;
import Builder.components.*;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public interface PCBuilder {
    public void buildCPU();
    public void buildVideoCard();
    public void buildMotherBoard();
    public PC getPC();
}
