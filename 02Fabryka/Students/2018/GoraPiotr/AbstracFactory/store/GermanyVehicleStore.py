from element_factory.ElementFactory import ElementFactory
from element_factory.GermanyElementFactory import GermanyElementFactory
from store.VehicleStore import VehicleStore
from vehicle.Vehicle import Vehicle
from vehicle.fiat.Bravo import Bravo
from vehicle.fiat.Punto import Punto
from vehicle.seat.Ibiza import Ibiza


class GermanyVehicleStore(VehicleStore):

    def create_vehicle(self, vehicle_type: str):
        vehicle: Vehicle = None
        element_factory: ElementFactory = GermanyElementFactory()

        if vehicle_type == 'bravo':
            vehicle = Bravo(element_factory)
        if vehicle_type == 'punto':
            vehicle = Punto(element_factory)
        if vehicle_type == 'ibiza':
            vehicle = Ibiza(element_factory)
        return vehicle
