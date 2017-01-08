package fabric.simpleFabric

import fabric.simpleFabric.models.AUDIVehicle
import fabric.simpleFabric.models.BMWVehicle
import fabric.simpleFabric.models.MazdaVehicle
import fabric.simpleFabric.models.Vehicle

class VehicleSimpleFabric {

    fun createVehicle (which: VehicleTypeEnum) : Vehicle {
        var vehicle: Vehicle = Vehicle()

        when (which) {
            VehicleTypeEnum.BMW -> vehicle = BMWVehicle()
            VehicleTypeEnum.AUDI -> vehicle = AUDIVehicle()
            VehicleTypeEnum.MAZDA -> vehicle = MazdaVehicle()
            else -> {
                print("wrong vehicle type")
            }
        }

        return vehicle
    }

}