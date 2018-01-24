package design.patterns.singleton;

import design.patterns.client.Color;
import design.patterns.iterator.PrinterIterator;
import design.patterns.printers.Printer;

import java.util.List;
import java.util.concurrent.Semaphore;

public class SuppliesSingleton {

    private static SuppliesSingleton instance;

    private static Semaphore semaphore = new Semaphore(1);
    private Supplies supplies;

    private SuppliesSingleton() {
        supplies = new Supplies();
    }

    public static SuppliesSingleton getInstance() {
        if (instance == null) {
            synchronized (SuppliesSingleton.class) {
                instance = new SuppliesSingleton();
            }
        }

        return instance;
    }

    public void addAllSupplies(Integer blackInk, Integer colorInk, List<Printer> printers, Integer paper) {
        addBlackInk(blackInk);
        addColorInk(colorInk);
        addPaper(paper);
        supplies.setPrinters(printers);
    }

    public void addBlackInk(Integer blackInk) {
        supplies.setBlackInk(supplies.getBlackInk() + blackInk);
    }

    public void addColorInk(Integer colorInk) {
        supplies.setColorInk(supplies.getColorInk() + colorInk);
    }

    public void addPaper(Integer paper) {
        supplies.setPaper(supplies.getPaper() + paper);
    }

    public PrinterIterator getIterator() {
        return new PrinterIterator();
    }

    public Supplies getSupplies() {
        return supplies;
    }

    public Printer findFirstNotBusyForColor(Color color) {
        try {
            semaphore.acquire();
            try {
                for (PrinterIterator iterator = instance.getIterator(); iterator.hasNext(); ) {
                    Printer next = iterator.next();
                    if (next.isFree() && ((color.equals(Color.COLOR) && next.isColorPrinter())
                            || (color.equals(Color.BLACK_WHITE) && !next.isColorPrinter()))) {
                        return next;
                    }
                }
            } finally {
                semaphore.release();
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        return null;
    }
}
