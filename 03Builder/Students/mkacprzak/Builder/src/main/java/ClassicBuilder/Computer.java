package ClassicBuilder;

import FluentBuilder.*;

public class Computer {

    private Type type;
    private GPU gpu;
    private CPU cpu;
    private Ram ram;
    private Motherboard motherboard;

    public Type getType() {
        return type;
    }

    public void setType(Type type) {
        this.type = type;
    }

    public GPU getGpu() {
        return gpu;
    }

    public void setGpu(GPU gpu) {
        this.gpu = gpu;
    }

    public CPU getCpu() {
        return cpu;
    }

    public void setCpu(CPU cpu) {
        this.cpu = cpu;
    }

    public Ram getRam() {
        return ram;
    }

    public void setRam(Ram ram) {
        this.ram = ram;
    }

    public Motherboard getMotherboard() {
        return motherboard;
    }

    public void setMotherboard(Motherboard motherboard) {
        this.motherboard = motherboard;
    }

    @Override
    public String toString() {
        return "Computer{" +
                "type=" + type +
                ", gpu=" + gpu +
                ", cpu=" + cpu +
                ", ram=" + ram +
                ", motherboard=" + motherboard +
                '}';
    }
}
