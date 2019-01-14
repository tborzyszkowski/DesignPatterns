package DeepPrototype;

import DeepPrototype.enums.CoputerType;
import DeepPrototype.enums.ProcessorType;
import DeepPrototype.enums.RamType;

public class ComputerManager {

    public Computer createComputer() {
        Ram ram = new Ram(16, RamType.DDR2);
        Processor processor = new Processor(ProcessorType.i5, 2.4);
        return new Computer(
                CoputerType.ULTRABOOK,
                ram,
                processor,
                15
        );
    }

}
