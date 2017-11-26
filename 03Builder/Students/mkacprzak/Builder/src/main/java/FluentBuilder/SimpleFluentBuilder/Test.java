package FluentBuilder.SimpleFluentBuilder;

import FluentBuilder.*;

public class Test {


    public static void main(String[] args)
    {

        Computer computer = new Computer().cpu(CPU.INTEL).gpu(GPU.NVIDIA).type(Type.NORMAL).motherboard(Motherboard.MICROATX).ram(Ram.DDR3);
        System.out.println(computer);

    }
}
