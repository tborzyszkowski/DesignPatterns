package com.marchwinski.prototype.constructorCopy;

import java.io.Serializable;

public class Sauce implements Serializable {
    private String kindOfSauce;

    public Sauce(Sauce otherSauce) {
        this.kindOfSauce = otherSauce.kindOfSauce;
    }

    public Sauce(String kindOfSauce) {
        this.kindOfSauce = kindOfSauce;
    }

    public String getKindOfSauce() {
        return kindOfSauce;
    }


}
