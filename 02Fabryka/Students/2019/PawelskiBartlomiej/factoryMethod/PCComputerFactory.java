package factoryMethod;
import computers.*;

public enum PCComputerFactory implements ComputerFactory {
    INSTANCE;
    public Computer computer;


    @Override
    public void sendRequestToFactory(String intendedFor) throws Exception {
        this.computer = createComputer(intendedFor);
    }

    @Override
    public Computer createComputer(String intendedFor) throws Exception {
        if (intendedFor.equals("Office")) return new ComputerPCOffice();
        else if (intendedFor.equals("Gaming")) return new ComputerPCGaming();
        else throw new Exception("Type or intend doesn't exist!");
    }

}
