import java.io.Serializable;

public class Specification implements Serializable{

    private int penetration;
    private int diameter;

    @Override
    public String toString() {
        return "Power{" +
                "penetration=" + penetration +
                ", diameter=" + diameter +
                '}';
    }

    public Specification penetration(int penetration)
    {
        this.penetration=penetration;
        return this;
    }
    public Specification diameter(int diameter)
    {
        this.diameter=diameter;
        return this;
    }

    public int getPenetration() {
        return penetration;
    }

    public void setPenetration(int penetration) {
        this.penetration = penetration;
    }

    public int getDiameter() {
        return diameter;
    }

    public void setDiameter(int diameter) {
        this.diameter = diameter;
    }
}
