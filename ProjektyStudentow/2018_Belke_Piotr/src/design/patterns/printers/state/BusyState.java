package design.patterns.printers.state;

import design.patterns.printers.Printer;
import design.patterns.printers.PrinterState;

public class BusyState implements PrinterState {

    @Override
    public String getStateType() {
        return "BUSY";
    }

    @Override
    public void doAction(Printer context) {
        context.setState(this);
    }
}
