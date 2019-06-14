package DeepPrototype;

public class Glass implements Cloneable {

    private String type;

    public Glass(String glassType) {
        type = glassType;
    }

    public String getNameOfType() {
        return type;
    }

    public void setNameOfType(String glassType) {
        type = glassType;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        Glass copyGlass = (Glass) super.clone();
        return copyGlass;
    }
}
