package ClassicBuilder;

import FluentBuilder.CPU;
import FluentBuilder.GPU;
import FluentBuilder.Motherboard;
import FluentBuilder.Ram;

public class ComputerManufacturer {

    ComputerBuilder builder;

            public ComputerManufacturer(ComputerBuilder computerBuilder)
            {
                this.builder=computerBuilder;
            }

    public void makeComputer(){
     builder.putCPU(CPU.INTEL);
     builder.putGPU(GPU.NVIDIA);
     builder.putMotherboard(Motherboard.MICROATX);
     builder.putRam(Ram.DDR1);
    }

    public Computer getComputer(){
        makeComputer();
        return builder.buildComputer();
    }
}
