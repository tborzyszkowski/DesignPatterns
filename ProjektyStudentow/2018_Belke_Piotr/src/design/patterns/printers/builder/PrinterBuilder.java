package design.patterns.printers.builder;

import design.patterns.printers.Printer;

import java.util.UUID;

public class PrinterBuilder {

    private Printer printer;

    public Printer build() {
        return this.printer;
    }

    public PrinterBuilder newInstance() {
        this.printer = new Printer();
        return this;
    }

    public PrinterBuilder setOnlyBlack(Boolean onlyBlack) {
        if (onlyBlack && this.printer.getColorInk() != null) {
            this.printer.setColorInk(null);
        }
        this.printer.setOnlyBlack(onlyBlack);
        return this;
    }

    public PrinterBuilder setBlackInk(Integer blackInk) {
        this.printer.setBlackInk(blackInk);
        return this;
    }

    public PrinterBuilder setColorInk(Integer colorInk) {
        if (!this.printer.getOnlyBlack()) {
            this.printer.setColorInk(colorInk);
        }
        return this;
    }

    public PrinterBuilder setPaper(Integer paper) {
        this.printer.setPaper(paper);
        return this;
    }

    public PrinterBuilder setId(UUID id) {
        this.printer.setId(id);
        return this;
    }

    public PrinterBuilder setMaxPaper(Integer maxPaper) {
        this.printer.setMaxPaper(maxPaper);
        return this;
    }
}
