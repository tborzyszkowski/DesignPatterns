package fabric.abstractFabric.models

import fabric.abstractFabric.DiskType
import fabric.abstractFabric.LaptopType

class Laptop (ram: Int, cpu: String, diskType: DiskType, diskSize: Number, weightInKg: Number, val laptopType: LaptopType ) :
        Computer(ram, cpu, diskType, diskSize, weightInKg){

    override fun toString(): String {
        return super.toString() + " and it's ${laptopType.name}"
    }
}