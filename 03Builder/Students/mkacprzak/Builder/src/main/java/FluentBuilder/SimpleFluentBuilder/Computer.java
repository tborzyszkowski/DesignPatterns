package FluentBuilder.SimpleFluentBuilder;

import FluentBuilder.*;

public class Computer {

    private Type type;
    private GPU gpu;
    private CPU cpu;
    private Ram ram;
    private Motherboard motherboard;


public Computer type(Type type)
{
    this.type=type;
    return this;
}
    public Computer cpu(CPU cpu)
    {
        this.cpu=cpu;
        return this;
    }
    public Computer ram(Ram ram)
    {
        this.ram=ram;
        return this;
    }
    public Computer gpu(GPU gpu)
    {
        this.gpu=gpu;
        return this;
    }
    public Computer motherboard(Motherboard motherboard)
    {
        this.motherboard=motherboard;
        return this;
    }

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
}
