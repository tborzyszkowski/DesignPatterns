fun main(args: Array<String>) {
    val lowEnd = LaptopBuilder("Acer").withCpu(Cpu.i3).withRam(SDRRam(2048, 100f)).withGpu(Gpu.INTEL).toLaptop();
    val middleEnd = LaptopBuilder("Asus").withCpu(Cpu.i5).withRam(SDRRam(4096, 200f)).withGpu(Gpu.RADEON).toLaptop();
    val highEnd = LaptopBuilder("Dell").withCpu(Cpu.i7).withRam(SDRRam(8192, 400f)).withGpu(Gpu.NVIDIA).toLaptop();

    println("low end: " + lowEnd)
    println("middle end: " + middleEnd)
    println("high end: " + highEnd)
}
