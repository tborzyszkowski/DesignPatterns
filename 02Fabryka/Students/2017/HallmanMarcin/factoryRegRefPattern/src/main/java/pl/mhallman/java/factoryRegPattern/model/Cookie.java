package pl.mhallman.java.factoryRegPattern.model;

import java.util.List;

public abstract class Cookie {

    protected String name;

    protected String flour;

    protected String milk;

    protected String topping;

    protected List<String> additives;

    public abstract Cookie createCookie();

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getFlour() {
        return flour;
    }

    public void setFlour(String flour) {
        this.flour = flour;
    }

    public String getMilk() {
        return milk;
    }

    public void setMilk(String milk) {
        this.milk = milk;
    }

    public String getTopping() {
        return topping;
    }

    public void setTopping(String topping) {
        this.topping = topping;
    }

    public List<String> getAdditives() {
        return additives;
    }

    public void setAdditives(List<String> additives) {
        this.additives = additives;
    }

    @Override
    public String toString() {
        return "Cookie{" +
                "name='" + name + '\'' +
                ", flour='" + flour + '\'' +
                ", milk='" + milk + '\'' +
                ", topping='" + topping + '\'' +
                ", additives=" + additives +
                '}';
    }

}
