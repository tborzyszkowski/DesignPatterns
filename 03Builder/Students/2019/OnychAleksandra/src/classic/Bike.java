package classic;

import classic.enums.BikeType;
import classic.enums.FrameType;

public class Bike {
    private BikeType type;
    private float wheelsSize;
    private FrameType frameType;
    private int wheelsNumber;
    private boolean electricEngine;

    public BikeType getType() {
        return type;
    }

    public float getWheelsSize() {
        return wheelsSize;
    }

    public FrameType getFrameType() {
        return frameType;
    }

    public int getWheelsNumber() {
        return wheelsNumber;
    }

    public boolean isElectricEngine() {
        return electricEngine;
    }

    public void setType(BikeType type) {
        this.type = type;
    }

    public void setWheelsSize(float wheelsSize) {
        this.wheelsSize = wheelsSize;
    }

    public void setFrameType(FrameType frameType) {
        this.frameType = frameType;
    }

    public void setWheelsNumber(int wheelsNumber) {
        this.wheelsNumber = wheelsNumber;
    }

    public void setElectricEngine(boolean electricEngine) {
        this.electricEngine = electricEngine;
    }

    @Override
    public String toString() {
        return "classic.Bike{" +
                "type=" + type +
                ", wheelsSize=" + wheelsSize +
                ", frameType=" + frameType +
                ", wheelsNumber=" + wheelsNumber +
                ", electricEngine=" + electricEngine +
                '}';
    }

}
