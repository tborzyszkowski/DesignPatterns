public class Bike implements Cloneable {

    private String type;
    private Wheel wheel;
    private Frame frame;

    public Wheel getWheel() {
        return wheel;
    }

    public Frame getFrame() {
        return frame;
    }

    public void setType(String type) {
        this.type = type;
    }

    public void setWheel(Wheel wheel) {
        this.wheel = wheel;
    }

    public void setFrame(Frame frame) {
        this.frame = frame;
    }

    public Bike (String type) {
        this.type = type;
    }

    public Bike wheel(Wheel wheel) {
        this.wheel = wheel;
        return this;
    }

    public Bike frame (Frame frame) {
        this.frame = frame;
        return this;
    }

    @Override
    protected Bike clone() {
        try {
            Bike bike = (Bike) super.clone();
            bike.wheel = wheel.clone();
            bike.frame = frame.clone();
            return bike;
        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
            return null;
        }
    }

    public Bike shallowCopy() {
        try {
            return (Bike) super.clone();
        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
            return null;
        }
    }

    @Override
    public String toString() {
        return "Bike{" +
                "type='" + type + '\'' +
                ", wheel=" + wheel +
                ", frame=" + frame +
                '}';
    }
}
