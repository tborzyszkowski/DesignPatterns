package Builder;
import Builder.components.*;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public class OfficePC implements PCBuilder {

    private PC pc;

    public OfficePC (){
        this.pc = new PC();
    }

    public void buildCPU(){
        CPU cpu = new CPU();
        cpu.setName("Core i5 2500K");
        pc.setCpu(cpu);

    }
    public void buildVideoCard(){
        VideoCard vc = new VideoCard();
        vc.setName("Radeon HD 250");
        pc.setVideoCard(vc);

    }
    public void buildMotherBoard(){
        MotherBoard mb = new MotherBoard();
        mb.setName("Asus C1");
        pc.setMotherBoard(mb);

    }
    public PC getPC(){
    return pc;
    }
}
