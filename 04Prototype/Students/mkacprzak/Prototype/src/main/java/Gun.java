import java.io.Serializable;

public class Gun implements Serializable{

    private String type;
    private Specification specification;

    @Override
    public String toString() {
        return "Gun{" +
                "type='" + type + '\'' +
                ", specification=" + specification +
                '}';
    }

    public Gun type(String type) {
        this.type = type;
        return this;
    }

    public Gun specification(Specification specification) {
        this.specification = specification;
        return this;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Specification getSpecification() {
        return specification;
    }

    public void setSpecification(Specification specification) {
        this.specification = specification;
    }
}
