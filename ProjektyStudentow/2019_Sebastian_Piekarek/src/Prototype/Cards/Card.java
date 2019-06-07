package Prototype.Cards;

public abstract class Card implements Cloneable {

    protected int id;
    protected String color = "";
    protected String name;
    protected int value;


    public Card setColor(String color){
        this.color = color;
        return this;
    }

    public String getName() {
        return name;
    }

    public int getValue(){
        return value;
    }

    @Override
    public String toString() {
        return name + color;
    }

    public Object clone() {
        Object clone = null;

        try {
            clone = super.clone();

        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
        }

        return clone;
    }



}