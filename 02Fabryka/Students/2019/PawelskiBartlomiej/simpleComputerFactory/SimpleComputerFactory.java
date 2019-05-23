package simpleComputerFactory;

import computers.*;

public enum SimpleComputerFactory {
    INSTANCE;
    public Computer computer;

    public void sendRequestToFactory(String type, String intendedFor) throws Exception {
        if (type.equals("PC") && intendedFor.equals("Gaming")) this.computer = new ComputerPCGaming();
        else if (type.equals("PC") && intendedFor.equals("Office")) this.computer = new ComputerPCOffice();
        else if (type.equals("Notebook") && intendedFor.equals("Gaming")) this.computer = new ComputerNotebookGaming();
        else if (type.equals("Notebook") && intendedFor.equals("Office")) this.computer = new ComputerNotebookOffice();
        else throw new Exception("Type or intend doesn't exist!");
    }

}
