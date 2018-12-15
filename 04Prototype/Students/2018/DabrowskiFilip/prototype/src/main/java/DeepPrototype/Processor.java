package DeepPrototype;

import DeepPrototype.enums.ProcessorType;

public class Processor {

    public ProcessorType processorType;
    public double processorClockSpeed;

    public Processor(ProcessorType processorType, double processorClockSpeed) {
        this.processorType = processorType;
        this.processorClockSpeed = processorClockSpeed;
    }

    public Processor clone() {
        return new Processor(this.processorType, this.processorClockSpeed);
    }

    @Override
    public String toString() {
        return "Processor{" +
                "processorType=" + processorType.toString() +
                ", processorClockSpeed=" + processorClockSpeed +
                '}';
    }
}
