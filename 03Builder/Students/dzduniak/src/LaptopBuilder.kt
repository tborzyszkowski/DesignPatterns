class LaptopBuilder(val name:String) {
    private var cpu: Cpu? = null;
    private var ram: Ram? = null;
    private var gpu: Gpu? = null;

    fun withCpu(cpu:Cpu): LaptopBuilder {
        this.cpu = cpu;
        return this;
    }

    fun withGpu(gpu:Gpu): LaptopBuilder {
        this.gpu = gpu;
        return this;
    }

    fun withRam(ram:Ram): LaptopBuilder {
        this.ram = ram;
        return this;
    }

    fun toLaptop() = Laptop(cpu!!, ram!!, gpu!!)
}
