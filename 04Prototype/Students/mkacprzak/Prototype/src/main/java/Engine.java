import java.io.Serializable;

public class Engine implements Serializable {

    private int power;

    @Override
    public String toString() {
        return "Engine{" +
                "power=" + power +
                '}';
    }

    public Engine power(int power)
    {
        this.power=power;
        return this;
    }

    public int getPower() {
        return power;
    }

    public void setPower(int power) {
        this.power = power;
    }
}
