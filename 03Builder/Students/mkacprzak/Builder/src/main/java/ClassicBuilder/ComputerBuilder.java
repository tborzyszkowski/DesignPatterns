package ClassicBuilder;

import FluentBuilder.CPU;
import FluentBuilder.GPU;
import FluentBuilder.Motherboard;
import FluentBuilder.Ram;

public interface ComputerBuilder {

    public void putCPU(CPU cpu);
    public void putGPU(GPU gpu);
    public void putRam(Ram ram);
    public void putMotherboard(Motherboard motherboard);
    public Computer buildComputer();
}
