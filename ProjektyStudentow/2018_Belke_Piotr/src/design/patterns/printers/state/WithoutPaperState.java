package design.patterns.printers.state;

import design.patterns.printers.Printer;
import design.patterns.printers.PrinterState;

public class WithoutPaperState implements PrinterState {

    @Override
    public String getStateType() {
        return "WITHOUT_PAPER";
    }

    @Override
    public void doAction(Printer context) {
        context.setState(this);
    }
}
