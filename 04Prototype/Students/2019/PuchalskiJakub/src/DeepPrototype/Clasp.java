package DeepPrototype;

public class Clasp implements Cloneable {

    private String type;

    public Clasp(String type) {
        this.type = type;
    }

    public String getNameOfType() {
        return type;
    }

    public void setNameOfType(String type) {
        this.type = type;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        Clasp copyClasp = (Clasp) super.clone();
        return copyClasp;
    }

}
