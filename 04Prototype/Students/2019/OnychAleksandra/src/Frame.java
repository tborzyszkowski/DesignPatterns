public class Frame implements Cloneable {

    private Type type;
    private int size;

    public Frame(Type type) {
        this.type = type;
    }

    public Frame size(int size) {
        this.size = size;
        return this;
    }

    public Type getType() {
        return type;
    }

    public int getSize() {
        return size;
    }

    public void setType(Type type) {
        this.type = type;
    }

    public void setSize(int size) {
        this.size = size;
    }

    @Override
    protected Frame clone() {
        try {
            Frame frame = (Frame) super.clone();
            frame.type = type.clone();
            return frame;
        } catch (CloneNotSupportedException e) {
            e.printStackTrace();
            return null;
        }
    }

    @Override
    public String toString() {
        return "Frame{" +
                "type=" + type +
                ", size=" + size +
                '}';
    }
}
