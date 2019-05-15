package fluent;

import classic.enums.BikeType;
import classic.enums.FrameType;

public class Bike {
    private BikeType type;
    private float wheelsSize;
    private FrameType frameType;
    private int wheelsNumber;
    private boolean electricEngine;

    private Bike(Builder builder) {
        this.type = builder.type;
        this.wheelsSize = builder.wheelsSize;
        this.wheelsNumber = builder.wheelsNumber;
        this.frameType = builder.frameType;
        this.electricEngine = builder.electricEngine;
    }

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

    @Override
    public String toString() {
        return "Bike{" +
                "type=" + type +
                ", wheelsSize=" + wheelsSize +
                ", frameType=" + frameType +
                ", wheelsNumber=" + wheelsNumber +
                ", electricEngine=" + electricEngine +
                '}';
    }

    public static class Builder {
        private BikeType type;
        private float wheelsSize;
        private FrameType frameType;
        private int wheelsNumber;
        private boolean electricEngine;

        public Builder (BikeType type) {
            this.type = type;
        }

        public Builder wheelsSize(float wheelsSize) {
            this.wheelsSize = wheelsSize;
            return this;
        }

        public Builder frameType(FrameType frameType) {
            this.frameType = frameType;
            return this;
        }

        public Builder wheelsNumber(int wheelsNumber) {
            this.wheelsNumber = wheelsNumber;
            return this;
        }

        public Builder electricEngine(boolean electricEngine) {
            this.electricEngine = electricEngine;
            return this;
        }

        public Bike build() {
            return new Bike(this);
        }
    }
}
