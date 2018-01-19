package design.patterns.printers.state;

import design.patterns.printers.Printer;
import design.patterns.printers.PrinterState;

public class WithoutBlackInkState implements PrinterState {

    @Override
    public String getStateType() {
        return "WITHOUT_BLACK_INK";
    }

    @Override
    public void doAction(Printer context) {
        context.setState(this);
    }
}
