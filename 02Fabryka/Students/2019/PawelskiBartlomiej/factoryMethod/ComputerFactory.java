package factoryMethod;
import computers.*;

interface ComputerFactory {

    void sendRequestToFactory(String intendedFor) throws Exception;
    Computer createComputer(String intendedFor) throws Exception;
}
