package DeepPrototype;

import DeepPrototype.enums.CoputerType;

public class Computer implements Cloneable {

    private CoputerType coputerType;
    private Ram ram;
    private Processor processor;
    private int screenSize;

    public Computer(CoputerType coputerType, Ram ram, Processor processor, int screenSize) {
        this.coputerType = coputerType;
        this.ram = ram;
        this.processor = processor;
        this.screenSize = screenSize;
    }

    public Computer clone() {
        return new Computer(this.coputerType, this.ram.clone(), this.processor.clone(), this.screenSize);
    }

    public CoputerType getCoputerType() {
        return coputerType;
    }

    public void setCoputerType(CoputerType coputerType) {
        this.coputerType = coputerType;
    }

    public Ram getRam() {
        return ram;
    }

    public void setRam(Ram ram) {
        this.ram = ram;
    }

    public Processor getProcessor() {
        return processor;
    }

    public void setProcessor(Processor processor) {
        this.processor = processor;
    }

    public int getScreenSize() {
        return screenSize;
    }

    public void setScreenSize(int screenSize) {
        this.screenSize = screenSize;
    }

    @Override
    public String toString() {
        return "Computer{" +
                "coputerType=" + coputerType +
                ", ram=" + ram.toString() +
                ", processor=" + processor.toString() +
                ", screenSize=" + screenSize +
                '}';
    }
}
