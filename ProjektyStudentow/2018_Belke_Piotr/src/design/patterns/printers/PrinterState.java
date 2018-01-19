package design.patterns.printers;

/**
 * Stan drukarki.
 */
public interface PrinterState {

    String getStateType();

    void doAction(Printer context);
}
