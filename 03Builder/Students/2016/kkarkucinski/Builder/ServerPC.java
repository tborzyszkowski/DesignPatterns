package Builder;
import Builder.components.*;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public class ServerPC implements PCBuilder {

    private PC pc;

    public ServerPC (){
        this.pc = new PC();
    }

    public void buildCPU(){
        CPU cpu = new CPU();
        cpu.setName("Core i7 8500K");
        pc.setCpu(cpu);

    }
    public void buildVideoCard(){
        VideoCard vc = new VideoCard();
        vc.setName("GF 1080 GTX ");
        pc.setVideoCard(vc);

    }
    public void buildMotherBoard(){
        MotherBoard mb = new MotherBoard();
        mb.setName("MSI Monster X99");
        pc.setMotherBoard(mb);

    }
    public PC getPC(){
        return pc;
    }
}
