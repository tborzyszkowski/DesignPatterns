package fabric.abstractFabric.factories

import fabric.abstractFabric.DiskType
import fabric.abstractFabric.LaptopType
import fabric.abstractFabric.models.Computer
import fabric.abstractFabric.models.Laptop
import fabric.abstractFabric.models.PC


class LaptopFactory constructor() : ComputerFactoryInterface {

    constructor(givenLaptopType: LaptopType) : this() {
        laptopType = givenLaptopType
    }

    var laptopType: LaptopType = LaptopType.NOTEBOOK
    var ram: Int = 0
    var cpu: String = ""
    var diskType: DiskType = DiskType.HDD
    var diskSize: Number = 0
    var weightInKg: Number = 0

    override fun buildComputer(): Computer {
        when (laptopType) {
            LaptopType.NETBOOK -> {
                cpu = "Intel m1"
                diskSize = 128
                diskType = DiskType.HDD
                weightInKg = 1
                ram = 4
            }
            LaptopType.NOTEBOOK -> {
                ram = 8
                cpu = "Intel i3"
                diskType = DiskType.HDD
                diskSize = 1024
                weightInKg = 4
            }
            LaptopType.ULTRABOOK -> {
                ram = 16
                cpu = "Intel i7"
                diskSize = 512
                diskType = DiskType.SDD
                weightInKg = 2
            }
        }

        val laptop: Computer = Laptop(ram, cpu, diskType, diskSize, weightInKg, laptopType)
        println("building ${laptop}")
        return laptop
    }
}