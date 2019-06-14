package factory.components.glass;

public abstract class GlassType implements Cloneable {

    protected String glassType;

    public String getGlassType() {
        return glassType;
    }

    public void setGlassType(String glassType) {
        this.glassType = glassType;
    }

    @Override
    public Object clone() throws CloneNotSupportedException {
        GlassType copyGlass = (GlassType) super.clone();
        return copyGlass;
    }
}
