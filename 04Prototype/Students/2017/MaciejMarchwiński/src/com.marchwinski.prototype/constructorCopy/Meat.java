package com.marchwinski.prototype.constructorCopy;

import java.io.Serializable;

public class Meat implements Serializable {

    private String kindOfMeat;
    private int numberOfSlices;

    public Meat(Meat otherMeat) {
        this.kindOfMeat = otherMeat.kindOfMeat;
        this.numberOfSlices = otherMeat.numberOfSlices;
    }

    public Meat(String kindOfMeat, int numberOfSlices) {
        this.kindOfMeat = kindOfMeat;
        this.numberOfSlices = numberOfSlices;
    }


    public String getKindOfMeat() {
        return kindOfMeat;
    }

    public int getNumberOfSlices() {
        return numberOfSlices;
    }

    public void setKindOfMeat(String kindOfMeat) {
        this.kindOfMeat = kindOfMeat;
    }

    public void setNumberOfSlices(int numberOfSlices) {
        this.numberOfSlices = numberOfSlices;
    }

    @Override
    public String toString() {
        return "Meat{" +
                "kindOfMeat(String)='" + kindOfMeat + '\'' +
                ", numberOfSlices(int)=" + numberOfSlices +
                '}';
    }
}
