package FluentBuilder;

import java.util.BitSet;

public class Computer {

    private Computer(){}

    @Override
    public String toString() {
        return "Computer{" +
                "type=" + type +
                ", gpu=" + gpu +
                ", cpu=" + cpu +
                ", ram=" + ram +
                ", motherboard=" + motherboard +
                '}';
    }

    private Type type;
    private GPU gpu;
    private CPU cpu;
    private Ram ram;
    private Motherboard motherboard;

    public static Builder builder()
    {
        return new Builder();
    }


    public static class Builder {

        Computer computer = new Computer();

        private Builder()
        {}

        public Builder type(Type type)
        {
            computer.type=type;
            return this;
        }


        public Builder gpu(GPU gpu)
        {
            computer.gpu=gpu;
            return this;
        }
        public Builder cpu(CPU cpu)
        {
            computer.cpu=cpu;
            return this;
        }
        public Builder ram(Ram ram)
        {
            computer.ram=ram;
            return this;
        }

        public Builder motherboard(Motherboard mb)
        {
            computer.motherboard=mb;
            return this;
        }
        public Computer build()
        {
            return computer;
        }
    }



}

