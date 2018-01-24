package design.patterns.iterator;

import design.patterns.printers.Printer;
import design.patterns.singleton.SuppliesSingleton;

public class PrinterIterator {

    int index;

    public boolean hasNext() {
        return index < SuppliesSingleton.getInstance().getSupplies().getPrinters().size();
    }

    public Printer next() {
        if (this.hasNext()) {
            return SuppliesSingleton.getInstance().getSupplies().getPrinters().get(index++);
        }
        return null;
    }

}
