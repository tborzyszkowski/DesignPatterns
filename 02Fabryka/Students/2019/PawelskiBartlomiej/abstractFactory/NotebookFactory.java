package abstractFactory;

import computers.*;

public enum NotebookFactory implements AbstractComputerFactory {
    INSTANCE;
    public Computer computer;

    @Override
    public void createGamingComputer() {
        INSTANCE.computer = new ComputerNotebookGaming();
    }

    @Override
    public void createOfficeComputer() {
        INSTANCE.computer = new ComputerNotebookOffice();
    }
}
