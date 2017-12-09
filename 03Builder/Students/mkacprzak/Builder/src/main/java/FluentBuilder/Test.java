package FluentBuilder;

public class Test {


    public static void main(String[] args)
    {

        Computer computer = Computer.builder().cpu(CPU.INTEL).gpu(GPU.AMD).motherboard(Motherboard.ATX).ram(Ram.DDR4).type(Type.GAMING).build();

        System.out.println(computer);

    }
}
