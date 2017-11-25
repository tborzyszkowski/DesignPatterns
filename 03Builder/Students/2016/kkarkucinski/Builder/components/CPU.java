package Builder.components;

/**
 * Created by Karkucinski Krzysztof on 2016-12-09.
 */
public class CPU {

    private String name;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public String toString() {
        return "CPU{" +
                "name='" + name + '\'' +
                '}';
    }
}

