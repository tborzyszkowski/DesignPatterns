package com.company.Factory;

public class Animal {
    public int life = 100;
    public String direction = "N";
    public char name;

    public Animal() {

    }

    Boolean move() {
        return true;
    }

    void changeDirection(String changeTo) {
        direction = changeTo;
    }
}
