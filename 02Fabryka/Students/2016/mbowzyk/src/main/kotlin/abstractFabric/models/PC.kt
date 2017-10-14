package fabric.abstractFabric.models

import fabric.abstractFabric.DiskType

class PC(ram: Int, cpu: String, diskType: DiskType, diskSize: Number, weightInKg: Number ) :
        Computer(ram, cpu, diskType, diskSize, weightInKg){

    val computerClass: String = "PC computer"

    override fun toString(): String {
        return super.toString() + " and it's ${computerClass}"
    }
}