package com.marchwinski.factoryexamples.vehicles;

import com.marchwinski.factoryexamples.parts.Part;
import java.util.ArrayList;
import java.util.List;

public abstract class Vehicle {

    List<Part> partList = new ArrayList<>();

    @Override
    public String toString() {
        return partList.toString();
    }
}
