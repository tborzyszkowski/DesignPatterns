package fabric.abstractFabric.factories

import fabric.abstractFabric.DiskType
import fabric.abstractFabric.models.Computer
import fabric.abstractFabric.models.Server

class ServersFactory : ComputerFactoryInterface {

    val ram: Int = 64
    val cpu: String = "Intel Xeon E7 v4"
    val diskType: DiskType = DiskType.SDD
    val diskSize: Number = 524288
    val weightInKg: Number = 20

    override fun buildComputer(): Computer {
        val server: Computer = Server(ram, cpu, diskType, diskSize, weightInKg)
        println("building ${server}")
        return server
    }

}