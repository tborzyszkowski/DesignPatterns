package factory.components.strap;

public abstract class StrapType implements Cloneable {
    String strapType;

    public String getStrapType() {
        return strapType;
    }

    public void setStrapType(String strapType) {
        this.strapType = strapType;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        StrapType strapCopy = (StrapType) super.clone();
        return strapCopy;
    }

}
