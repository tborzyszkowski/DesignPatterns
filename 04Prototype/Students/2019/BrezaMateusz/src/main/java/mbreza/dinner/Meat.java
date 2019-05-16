package mbreza.dinner;

public class Meat implements Cloneable{
    private String meatType;

    public Meat(String meatType) {
        this.meatType = meatType;
    }

    public String getMeatType() {
        return meatType;
    }

    public void setMeatType(String meatType) {
        this.meatType = meatType;
    }

    @Override
    public Object clone() throws CloneNotSupportedException{
        Meat copyMeat = (Meat) super.clone();
        return copyMeat;
    }
}
