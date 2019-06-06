package BuilderVsFactory.Factory;

import FluentBuilder.*;

public enum PCFactory implements AbstractComputerFactory {
    INSTANCE;
    public Computer computer;

    @Override
    public void createOfficeComputer() {
        INSTANCE.computer = new ComputerPCOffice();
    }
}
