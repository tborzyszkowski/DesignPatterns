package fabric.abstractFabric.models

import fabric.abstractFabric.DiskType

open class Computer
    constructor(val ram: Int,val cpu: String,val diskType: DiskType,val diskSize: Number,val weightInKg: Number) {

    override fun toString(): String {
        return "${weightInKg} kg computer with ${ram} GB ram, ${cpu} cpu and ${diskSize} GB ${diskType.name} disk"
    }
}