package Builder;
import Builder.components.PC;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */

public class Client {

    public static void main(String[]args){
        PCBuilder pcBuilder = new OfficePC();
        PCDirector pcDirector = new PCDirector(pcBuilder);
        pcDirector.makePC();

        PC pc = pcDirector.getPC();
        System.out.print(pc);
    }
}
