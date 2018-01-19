package design.patterns.singleton;

import design.patterns.printers.Printer;

import java.util.ArrayList;
import java.util.List;

public class Supplies {

    private Integer blackInk;
    private Integer colorInk;
    private Integer paper;
    private List<Printer> printers;

    public Supplies() {
        blackInk = 0;
        colorInk = 0;
        paper = 0;
        printers = new ArrayList<>();
    }

    public Integer getBlackInk() {
        return blackInk;
    }

    public void setBlackInk(Integer blackInk) {
        this.blackInk = blackInk;
    }

    public Integer getColorInk() {
        return colorInk;
    }

    public void setColorInk(Integer colorInk) {
        this.colorInk = colorInk;
    }

    public Integer getPaper() {
        return paper;
    }

    public void setPaper(Integer paper) {
        this.paper = paper;
    }

    public List<Printer> getPrinters() {
        return printers;
    }

    public void setPrinters(List<Printer> printers) {
        this.printers = printers;
    }
}
