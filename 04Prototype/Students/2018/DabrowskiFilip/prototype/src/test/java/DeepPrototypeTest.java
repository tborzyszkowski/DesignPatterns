import DeepPrototype.Computer;
import DeepPrototype.ComputerManager;
import DeepPrototype.Processor;
import DeepPrototype.Ram;
import DeepPrototype.enums.CoputerType;
import DeepPrototype.enums.ProcessorType;
import DeepPrototype.enums.RamType;
import org.junit.Before;
import org.junit.Test;

public class DeepPrototypeTest {

    ComputerManager computerManager;

    @Before
    public void createComputerManager() {
        this.computerManager = new ComputerManager();
    }

    @Test
    public void createDeepPrototype() {

        Computer computer = computerManager.createComputer();

        Computer computerCopy = computer.clone();
        Computer computerCopy2 = computer.clone();

        computer.setScreenSize(13);

        computerCopy.setCoputerType(CoputerType.GAMING);
        computerCopy.setProcessor(new Processor(ProcessorType.i7, 2.4));

        computerCopy2.setRam(new Ram(8, RamType.DDR3));

        System.out.println(computer.toString());
        System.out.println(computerCopy.toString());
        System.out.println(computerCopy2.toString());

    }
}
