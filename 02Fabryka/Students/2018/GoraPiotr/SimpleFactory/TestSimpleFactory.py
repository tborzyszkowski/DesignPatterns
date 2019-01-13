import unittest

from fiat.Bravo import Bravo
from SimpleVehicleFactory import SimpleVehicleFactory
from VehicleStore import VehicleStore
from opel.Corsa import Corsa
from opel.Zafira import Zafira
from seat.Ibiza import Ibiza
from seat.Leon import Leon
from seat.Toledo import Toledo


class TestSimpleFactory(unittest.TestCase):
    def test_create_seat_leon(self):
        factory = SimpleVehicleFactory
        store = VehicleStore(factory)

        vehicle = store.order_vehicle('leon')

        self.assertIsInstance(vehicle, Leon)

    def test_create_seat_ibiza(self):
        factory = SimpleVehicleFactory
        store = VehicleStore(factory)

        vehicle = store.order_vehicle('ibiza')

        self.assertIsInstance(vehicle, Ibiza)

    def test_create_seat_toledo(self):
        factory = SimpleVehicleFactory
        store = VehicleStore(factory)

        vehicle = store.order_vehicle('toledo')

        self.assertIsInstance(vehicle, Toledo)

    def test_create_opel_corsa(self):
        factory = SimpleVehicleFactory
        store = VehicleStore(factory)

        vehicle = store.order_vehicle('corsa')

        self.assertIsInstance(vehicle, Corsa)

    def test_create_opel_zafira(self):
        factory = SimpleVehicleFactory
        store = VehicleStore(factory)

        vehicle = store.order_vehicle('zafira')

        self.assertIsInstance(vehicle, Zafira)

    def test_create_fiat_bravo(self):
        factory = SimpleVehicleFactory
        store = VehicleStore(factory)

        vehicle = store.order_vehicle('bravo')

        self.assertIsInstance(vehicle, Bravo)


if __name__ == '__main__':
    unittest.main()
