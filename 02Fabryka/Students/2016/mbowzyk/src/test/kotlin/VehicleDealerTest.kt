package fabric

import fabric.simpleFabric.*
import fabric.simpleFabric.models.*
import org.junit.Assert.assertTrue
import org.junit.Test

class VehicleDealerTest {

    val fixtures:Fixtures = Fixtures()

    @Test
    fun shouldGet3DifferentVehicles () {
        val fabric:VehicleSimpleFabric = VehicleSimpleFabric()
        val dealer:VehicleDealer = VehicleDealer(fabric)

        println(dealer.getCar(VehicleTypeEnum.BMW))
        println(dealer.getCar(VehicleTypeEnum.AUDI))
        println(dealer.getCar(VehicleTypeEnum.MAZDA))

        assertTrue(dealer.getCar(VehicleTypeEnum.BMW).hashCode()
                .equals(fixtures.bmwVehicle.hashCode()))
        assertTrue(dealer.getCar(VehicleTypeEnum.AUDI).hashCode()
                .equals(fixtures.audiVehicle.hashCode()))
        assertTrue(dealer.getCar(VehicleTypeEnum.MAZDA).hashCode()
                .equals(fixtures.mazdaVehicle.hashCode()))


    }

    class Fixtures {
        val bmwVehicle: BMWVehicle = BMWVehicle()
        val audiVehicle: AUDIVehicle = AUDIVehicle()
        val mazdaVehicle: MazdaVehicle = MazdaVehicle()
    }
}