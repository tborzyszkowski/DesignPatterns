package com.orderMeal.model;

public class OrderDB {
    private int id;
    private String name;
    private String wrapping;
    private double prise;

    public double getPrise() {
        return prise;
    }

    public OrderDB setPrise(double prise) {
        this.prise = prise;
        return this;
    }

    public int getId() {
        return id;
    }

    public OrderDB setId(int id) {
        this.id = id;
        return this;
    }

    public String getName() {
        return name;
    }

    public OrderDB setName(String name) {
        this.name = name;
        return this;
    }

    public String getWrapping() {
        return wrapping;
    }

    public OrderDB setWrapping(String wrapping) {
        this.wrapping = wrapping;
        return this;
    }

    @Override
    public String toString() {
        return "OrderDB{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", wrapping='" + wrapping + '\'' +
                ", prise=" + prise +
                '}';
    }
}
