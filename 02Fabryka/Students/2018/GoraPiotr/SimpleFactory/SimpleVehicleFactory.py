from fiat.Bravo import Bravo
from fiat.Punto import Punto
from opel.Corsa import Corsa
from opel.Zafira import Zafira
from seat.Ibiza import Ibiza
from seat.Leon import Leon
from seat.Mii import Mii
from seat.Toledo import Toledo


class SimpleVehicleFactory:
    def __init__(self):
        pass

    @staticmethod
    def create_vehicle(vehicle_type):
        vehicle = None

        if vehicle_type == 'leon':
            vehicle = Leon()
        if vehicle_type == 'ibiza':
            vehicle = Ibiza()
        if vehicle_type == 'toledo':
            vehicle = Toledo()
        if vehicle_type == 'mii':
            vehicle = Mii()
        if vehicle_type == 'zafira':
            vehicle = Zafira()
        if vehicle_type == 'corsa':
            vehicle = Corsa()
        if vehicle_type == 'bravo':
            vehicle = Bravo()
        if vehicle_type == 'punto':
            vehicle = Punto()
        return vehicle
