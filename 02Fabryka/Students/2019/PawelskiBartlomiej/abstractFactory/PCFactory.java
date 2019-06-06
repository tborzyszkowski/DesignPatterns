package abstractFactory;

import computers.*;

public enum PCFactory implements AbstractComputerFactory {
    INSTANCE;
    public Computer computer;

    @Override
    public void createGamingComputer() {
        INSTANCE.computer = new ComputerPCGaming();
    }

    @Override
    public void createOfficeComputer() {
        INSTANCE.computer = new ComputerPCOffice();
    }
}
