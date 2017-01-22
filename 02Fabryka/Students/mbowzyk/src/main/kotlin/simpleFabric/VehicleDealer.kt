package fabric.simpleFabric

import fabric.simpleFabric.models.Vehicle

class VehicleDealer (val factory : VehicleSimpleFabric){

    fun getCar (brand: VehicleTypeEnum) : Vehicle {

        var vehicle: Vehicle = factory.createVehicle(brand)

        return vehicle
    }

}