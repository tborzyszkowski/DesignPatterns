package BuilderVsFactory.Factory;

public abstract class Computer {
    String type;
    String intendedFor;
    String CPU;
    String GPU;
    int RAMinGB;
    int SSDinGB;

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getIntendedFor() {
        return intendedFor;
    }

    public void setIntendedFor(String intendedFor) {
        this.intendedFor = intendedFor;
    }

    public String getCPU() {
        return CPU;
    }

    public void setCPU(String CPU) {
        this.CPU = CPU;
    }

    public String getGPU() {
        return GPU;
    }

    public void setGPU(String GPU) {
        this.GPU = GPU;
    }

    public int getRAMinGB() {
        return RAMinGB;
    }

    public void setRAMinGB(int RAMinGB) {
        this.RAMinGB = RAMinGB;
    }

    public int getSSDinGB() {
        return SSDinGB;
    }

    public void setSSDinGB(int SSDinGB) {
        this.SSDinGB = SSDinGB;
    }

    @Override
    public String toString() {
        return "Computer{" +
                "type='" + type + '\'' +
                ", intendedFor='" + intendedFor + '\'' +
                ", CPU='" + CPU + '\'' +
                ", GPU='" + GPU + '\'' +
                ", RAMinGB=" + RAMinGB +
                ", SSDinGB=" + SSDinGB +
                '}';
    }

    public abstract Computer computerClone();
}
