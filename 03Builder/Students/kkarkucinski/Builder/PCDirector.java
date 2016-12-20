package Builder;

import Builder.components.PC;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public class PCDirector {
    private PCBuilder pcBuilder;

    public PCDirector(PCBuilder pcBuilder) {
        this.pcBuilder = pcBuilder;
    }

    public void makePC() {
        pcBuilder.buildCPU();
        pcBuilder.buildMotherBoard();
        pcBuilder.buildVideoCard();
    }

    public PC getPC() {
        return this.pcBuilder.getPC();
    }
}