package FluentBuilder;

public class Computer {
    private ComputerType computerType;
    private ComputerIntent computerIntent;
    private String processor;
    private int ramInGB;
    private int ssdInGB;

    Computer(ComputerBuilder builder) {
        this.computerType = builder.computerType;
        this.computerIntent = builder.computerIntent;
        this.processor = builder.processor;
        this.ramInGB = builder.ramInGB;
        this.ssdInGB = builder.ssdInGB;
    }

    public String getProcessor() {
        return processor;
    }

    public static class ComputerBuilder {
        private ComputerType computerType;
        private ComputerIntent computerIntent;
        private String processor;
        private int ramInGB;
        private int ssdInGB;

        public ComputerBuilder computerType(ComputerType computerType) {
            this.computerType = computerType;
            return this;
        }

        public ComputerBuilder computerIntent(ComputerIntent computerIntent) {
            this.computerIntent = computerIntent;
            return this;
        }

        public ComputerBuilder processor(String processor) {
            this.processor = processor;
            return this;
        }

        public ComputerBuilder ramInGB(int ramInGB) {
            this.ramInGB = ramInGB;
            return this;
        }

        public ComputerBuilder ssdInGB(int ssdInGB) {
            this.ssdInGB = ssdInGB;
            return this;
        }

        public Computer build() {
            return new Computer(this);
        }
    }
}
