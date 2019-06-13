package DeepPrototype;

public class Strap implements Cloneable {

    private String type;
    private Clasp claspType;

    public Strap(String type, Clasp claspType) {
        this.type = type;
        this.claspType = claspType;
    }

    public String getNameOfType() {
        return type;
    }

    public void setNameOfType(String strapType) {
        this.type = strapType;
    }

    public Clasp getClaspType() {
        return claspType;
    }

    public void setClaspType(Clasp claspType) {
        this.claspType = claspType;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        Strap strapCopy = (Strap) super.clone();
        strapCopy.claspType = (Clasp) claspType.clone();
        return strapCopy;
    }

}
