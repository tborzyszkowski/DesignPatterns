package com.marchwinski.prototype.constructorCopy;

import java.io.Serializable;

public class Cheese implements Serializable {

    private KindOfCheese kindOfCheese;
    private int numberOfSlices;

    public Cheese(Cheese otherCheese) {
        this.kindOfCheese = new KindOfCheese(otherCheese.kindOfCheese);
        this.numberOfSlices = otherCheese.numberOfSlices;
    }

    public Cheese(KindOfCheese kindOfCheese, int numberOfSlices) {
        this.kindOfCheese = kindOfCheese;
        this.numberOfSlices = numberOfSlices;
    }


    public KindOfCheese getKindOfCheese() {
        return kindOfCheese;
    }

    public int getNumberOfSlices() {
        return numberOfSlices;
    }



    public String toComplexString() {
        return "Cheese id = " + this +
                "kindOfCheese=" + kindOfCheese + "  ";
    }
}
