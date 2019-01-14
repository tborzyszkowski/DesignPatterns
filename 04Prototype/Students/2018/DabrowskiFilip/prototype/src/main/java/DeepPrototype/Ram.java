package DeepPrototype;

import DeepPrototype.enums.RamType;

public class Ram {
    public int ramSize;
    public RamType ramType;

    public Ram(int ramSize, RamType ramType) {
        this.ramSize = ramSize;
        this.ramType = ramType;
    }

    public Ram clone() {
        return new Ram(this.ramSize, this.ramType);
    }

    @Override
    public String toString() {
        return "Ram{" +
                "ramSize=" + ramSize +
                ", ramType=" + ramType +
                '}';
    }
}
