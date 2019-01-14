from store.VehicleStore import VehicleStore
from vehicle.poland.fiat.PolandBravo import PolandBravo
from vehicle.poland.fiat.PolandPunto import PolandPunto
from vehicle.poland.opel.PolandCorsa import PolandCorsa
from vehicle.poland.opel.PolandZafira import PolandZafira
from vehicle.poland.seat.PolandIbiza import PolandIbiza
from vehicle.poland.seat.PolandToledo import PolandToledo


class PolandVehicleStore(VehicleStore):

    def create_vehicle(self, vehicle_type):
        vehicle = None

        if vehicle_type == 'poland-bravo':
            vehicle = PolandBravo()
        if vehicle_type == 'poland-punto':
            vehicle = PolandPunto()
        if vehicle_type == 'poland-corsa':
            vehicle = PolandCorsa()
        if vehicle_type == 'poland-zafira':
            vehicle = PolandZafira()
        if vehicle_type == 'poland-ibiza':
            vehicle = PolandIbiza()
        if vehicle_type == 'poland-toledo':
            vehicle = PolandToledo()
        return vehicle
