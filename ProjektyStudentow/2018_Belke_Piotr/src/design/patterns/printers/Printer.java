package design.patterns.printers;

import design.patterns.observer.Observer;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

/**
 * Obiekt drukarki.
 */
public class Printer {

    /**
     * Czy drukarka drukuje tylko w czerni?
     */
    private Boolean isOnlyBlack;
    /**
     * Ilość czarnego tuszu.
     */
    private Integer blackInk;
    /**
     * Ilość kolorowego tuszu.
     */
    private Integer colorInk;
    /**
     * Ilość papieru.
     */
    private Integer paper;
    /**
     * Stan drukarki.
     */
    private PrinterState state;

    private UUID id;

    private List<Observer> observers;

    private Integer maxPaper;

    public Printer() {
        state = null;
        isOnlyBlack = false;
        observers = new ArrayList<>();
    }

    public Boolean getOnlyBlack() {
        return isOnlyBlack;
    }

    public void setOnlyBlack(Boolean onlyBlack) {
        isOnlyBlack = onlyBlack;
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

    public PrinterState getState() {
        return state;
    }

    public void setState(PrinterState state) {
        this.state = state;
        sendEventToObservers();
    }

    public Integer getMaxPaper() {
        return maxPaper;
    }

    public void setMaxPaper(Integer maxPaper) {
        this.maxPaper = maxPaper;
    }

    private void sendEventToObservers() {
        for (Observer observer : observers) {
            observer.update(this.state);
        }
    }

    public UUID getId() {
        return id;
    }

    public void setId(UUID id) {
        this.id = id;
    }

    public List<Observer> getObservers() {
        return observers;
    }

    @Override
    public String toString() {
        return "Printer{" +
                "id=" + id +
                ", isOnlyBlack=" + isOnlyBlack +
                ", blackInk=" + blackInk +
                ", colorInk=" + colorInk +
                ", paper=" + paper +
                ", state=" + state +
                ", observers=" + observers +
                ", maxPaper=" + maxPaper +
                '}';
    }

    public void attach(Observer observer) {
        observers.add(observer);
    }

    public boolean isFree() {
        return this.state == null;
    }

    public boolean isColorPrinter() {
        return this.getColorInk() != null;
    }

    public boolean errorState() {
        return "WITHOUT_PAPER".equals(this.state.getStateType()) || "WITHOUT_BLACK_INK".equals(this.state.getStateType())
                || "WITHOUT_COLOR_INK".equals(this.state.getStateType());
    }
}
