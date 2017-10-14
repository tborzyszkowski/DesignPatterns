package fabric.abstractFabric.factories

import fabric.abstractFabric.DiskType
import fabric.abstractFabric.models.Computer
import fabric.abstractFabric.models.PC

class PCFactory : ComputerFactoryInterface {

    val ram: Int = 16
    val cpu: String = "Intel i7 6900K"
    val diskType: DiskType = DiskType.SDD
    val diskSize: Number = 1024
    val weightInKg: Number = 7

    override fun buildComputer(): Computer {
        val pc: Computer = PC(ram, cpu, diskType, diskSize, weightInKg)
        println("building ${pc}")
        return pc
    }
}