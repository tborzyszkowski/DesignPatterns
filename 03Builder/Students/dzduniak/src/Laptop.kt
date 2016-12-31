class Laptop(val cpu: Cpu, val ram: Ram, val gpu:Gpu) {
    override fun toString(): String {
        return "Laptop(cpu=$cpu, ram=$ram, gpu=$gpu)"
    }
}
