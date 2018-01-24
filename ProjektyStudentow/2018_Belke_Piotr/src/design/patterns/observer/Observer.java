package design.patterns.observer;

import design.patterns.Constants;
import design.patterns.printers.Printer;
import design.patterns.printers.PrinterState;
import design.patterns.printers.state.BusyState;
import design.patterns.singleton.Supplies;
import design.patterns.singleton.SuppliesSingleton;

public class Observer {

    private Printer printer;

    public Observer(Printer printer) {
        this.printer = printer;
        this.printer.attach(this);
    }

    public void update(PrinterState state) {
        SuppliesSingleton instance = SuppliesSingleton.getInstance();
        Supplies supplies = instance.getSupplies();

        if (state != null) {
            switch (state.getStateType()) {
                case "WITHOUT_BLACK_INK":
                    System.out.println("Adding black ink to printer: " + printer.getId());
                    if (supplies.getBlackInk() == 0) {
                        instance.addBlackInk(10);
                    }
                    printer.setBlackInk(Constants.MAX_PAGES_BLACK_INK);
                    supplies.setBlackInk(supplies.getBlackInk() - 1);
                    changeToBusy();
                    break;
                case "WITHOUT_COLOR_INK":
                    System.out.println("Adding color ink to printer: " + printer.getId());
                    if (supplies.getColorInk() == 0) {
                        instance.addColorInk(10);
                    }
                    printer.setColorInk(Constants.MAX_PAGES_COLOR_INK);
                    supplies.setColorInk(supplies.getColorInk() - 1);
                    changeToBusy();
                    break;
                case "WITHOUT_PAPER":
                    System.out.println("Adding paper to printer: " + printer.getId());
                    if (supplies.getPaper() == 0) {
                        instance.addPaper(10000);
                    }
                    printer.setPaper(supplies.getPaper() >= printer.getMaxPaper() ? printer.getMaxPaper() : supplies.getPaper());
                    supplies.setPaper(supplies.getPaper() >= printer.getMaxPaper() ? supplies.getPaper() - printer.getMaxPaper() : 0);
                    changeToBusy();
                    break;
            }
        }
    }

    private void changeToBusy() {
        BusyState busyState = new BusyState();
        busyState.doAction(printer);
    }
}
