package mbreza.caseForBuilder;

import mbreza.classic.GameType;

public class PcSetBuilder {
    private String monitor;
    private String box;
    private String motherboard;
    private String psu;
    private String storage;
    private String ram;
    private String gpu;
    private String cpu;


    public PcSetBuilder( Builder builder) {
        monitor = builder.monitor;
        box = builder.box;
        motherboard = builder.motherboard;
        psu = builder.psu;
        storage = builder.storage;
        ram  = builder.ram;
        gpu = builder.gpu;
        cpu = builder.cpu;
    }

    public String getMonitor() {
        return monitor;
    }

    public String getBox() {
        return box;
    }

    public String getMotherboard() {
        return motherboard;
    }

    public String getPsu() {
        return psu;
    }

    public String getStorage() {
        return storage;
    }

    public String getRam() {
        return ram;
    }

    public String getGpu() {
        return gpu;
    }

    public String getCpu() {
        return cpu;
    }


    public static class Builder {
        private String monitor;
        private String box;
        private String motherboard;
        private String psu;
        private String storage;
        private String ram;
        private String gpu;
        private String cpu;;

        public Builder addMonitor(String monitor) {
            this.monitor = monitor;
            return this;
        }

        public Builder addBox(String box) {
            this.box = box;
            return this;
        }

        public Builder addMotherboard(String motherboard) {
            this.motherboard = motherboard;
            return this;
        }

        public Builder addPsu(String psu) {
            this.psu = psu;
            return this;
        }

        public Builder addStorage(String storage) {
            this.storage = storage;
            return this;
        }

        public Builder addRam(String ram) {
            this.ram = ram;
            return this;
        }

        public Builder addGpu(String gpu) {
            this.gpu = gpu;
            return this;
        }

        public Builder addCpu(String cpu) {
            this.cpu = cpu;
            return this;
        }

        public PcSetBuilder build() {
            return new PcSetBuilder(this);
        }
    }
}

