package ClassicBuilder;

import FluentBuilder.*;

public class GamingPcBuilder implements ComputerBuilder{

    Computer computer;

    public GamingPcBuilder()
    {
        this.computer= new Computer();
        computer.setType(Type.GAMING);

    }
    public void putCPU(CPU cpu) {

        computer.setCpu(cpu);

    }

    public void putGPU(GPU gpu) {

        computer.setGpu(gpu);

    }

    public void putRam(Ram ram) {

        computer.setRam(ram);
    }

    public void putMotherboard(Motherboard motherboard) {
        computer.setMotherboard(motherboard);

    }

    public Computer buildComputer() {
        return this.computer;
    }
}
