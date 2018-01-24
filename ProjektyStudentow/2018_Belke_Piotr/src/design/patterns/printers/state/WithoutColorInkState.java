package design.patterns.printers.state;

import design.patterns.printers.Printer;
import design.patterns.printers.PrinterState;

public class WithoutColorInkState implements PrinterState {

    @Override
    public String getStateType() {
        return "WITHOUT_COLOR_INK";
    }

    @Override
    public void doAction(Printer context) {
        context.setState(this);
    }
}
