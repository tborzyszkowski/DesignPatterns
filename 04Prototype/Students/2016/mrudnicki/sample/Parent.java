package sample;

import java.io.Serializable;

public class Parent implements Cloneable, Serializable {

    @Override
    public Object clone() throws CloneNotSupportedException {
        return super.clone();
    }

    private Child child;

    public Child getChild() {
        return child;
    }

    public void setChild(Child child) {
        this.child = child;
    }
}

