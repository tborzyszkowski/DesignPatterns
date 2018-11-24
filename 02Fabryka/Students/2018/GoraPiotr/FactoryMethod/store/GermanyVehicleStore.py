from store.VehicleStore import VehicleStore
from vehicle.germany.fiat.GermanyBravo import GermanyBravo
from vehicle.germany.fiat.GermanyPunto import GermanyPunto
from vehicle.germany.opel.GermanyCorsa import GermanyCorsa
from vehicle.germany.opel.GermanyZafira import GermanyZafira
from vehicle.germany.seat.GermanyIbiza import GermanyIbiza
from vehicle.germany.seat.GermanyToledo import GermanyToledo


class GermanyVehicleStore(VehicleStore):

    def create_vehicle(self, vehicle_type):
        vehicle = None

        if vehicle_type == 'germany-bravo':
            vehicle = GermanyBravo()
        if vehicle_type == 'germany-punto':
            vehicle = GermanyPunto()
        if vehicle_type == 'germany-corsa':
            vehicle = GermanyCorsa()
        if vehicle_type == 'germany-zafira':
            vehicle = GermanyZafira()
        if vehicle_type == 'germany-ibiza':
            vehicle = GermanyIbiza()
        if vehicle_type == 'germany-toledo':
            vehicle = GermanyToledo()
        return vehicle
