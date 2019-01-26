import unittest

from store.GermanyVehicleStore import GermanyVehicleStore
from store.PolandVehicleStore import PolandVehicleStore
from vehicle.germany.fiat.GermanyBravo import GermanyBravo
from vehicle.germany.fiat.GermanyPunto import GermanyPunto
from vehicle.germany.opel.GermanyCorsa import GermanyCorsa
from vehicle.germany.opel.GermanyZafira import GermanyZafira
from vehicle.germany.seat.GermanyIbiza import GermanyIbiza
from vehicle.germany.seat.GermanyToledo import GermanyToledo
from vehicle.poland.fiat.PolandBravo import PolandBravo
from vehicle.poland.fiat.PolandPunto import PolandPunto
from vehicle.poland.opel.PolandCorsa import PolandCorsa
from vehicle.poland.opel.PolandZafira import PolandZafira
from vehicle.poland.seat.PolandIbiza import PolandIbiza
from vehicle.poland.seat.PolandToledo import PolandToledo


class TestFactoryMethod(unittest.TestCase):
    def test_create_poland_fiat_bravo(self):
        poland_vehicle_store: PolandVehicleStore = PolandVehicleStore()
        vehicle = poland_vehicle_store.order_vehicle('poland-bravo')

        self.assertIsInstance(vehicle, PolandBravo)

    def test_create_poland_fiat_punto(self):
        poland_vehicle_store: PolandVehicleStore = PolandVehicleStore()
        vehicle = poland_vehicle_store.order_vehicle('poland-punto')

        self.assertIsInstance(vehicle, PolandPunto)

    def test_create_poland_opel_zafira(self):
        poland_vehicle_store: PolandVehicleStore = PolandVehicleStore()
        vehicle = poland_vehicle_store.order_vehicle('poland-zafira')

        self.assertIsInstance(vehicle, PolandZafira)

    def test_create_poland_opel_corsa(self):
        poland_vehicle_store: PolandVehicleStore = PolandVehicleStore()
        vehicle = poland_vehicle_store.order_vehicle('poland-corsa')

        self.assertIsInstance(vehicle, PolandCorsa)

    def test_create_poland_seat_ibiza(self):
        poland_vehicle_store: PolandVehicleStore = PolandVehicleStore()
        vehicle = poland_vehicle_store.order_vehicle('poland-ibiza')

        self.assertIsInstance(vehicle, PolandIbiza)

    def test_create_poland_seat_toledo(self):
        poland_vehicle_store: PolandVehicleStore = PolandVehicleStore()
        vehicle = poland_vehicle_store.order_vehicle('poland-toledo')

        self.assertIsInstance(vehicle, PolandToledo)

    def test_create_germany_fiat_bravo(self):
        germany_vehicle_store: GermanyVehicleStore = GermanyVehicleStore()
        vehicle = germany_vehicle_store.order_vehicle('germany-bravo')

        self.assertIsInstance(vehicle, GermanyBravo)

    def test_create_germany_fiat_punto(self):
        germany_vehicle_store: GermanyVehicleStore = GermanyVehicleStore()
        vehicle = germany_vehicle_store.order_vehicle('germany-punto')

        self.assertIsInstance(vehicle, GermanyPunto)

    def test_create_germany_opel_zafira(self):
        germany_vehicle_store: GermanyVehicleStore = GermanyVehicleStore()
        vehicle = germany_vehicle_store.order_vehicle('germany-zafira')

        self.assertIsInstance(vehicle, GermanyZafira)

    def test_create_germany_opel_corsa(self):
        germany_vehicle_store: GermanyVehicleStore = GermanyVehicleStore()
        vehicle = germany_vehicle_store.order_vehicle('germany-corsa')

        self.assertIsInstance(vehicle, GermanyCorsa)

    def test_create_germany_seat_ibiza(self):
        germany_vehicle_store: GermanyVehicleStore = GermanyVehicleStore()
        vehicle = germany_vehicle_store.order_vehicle('germany-ibiza')

        self.assertIsInstance(vehicle, GermanyIbiza)

    def test_create_germany_seat_toledo(self):
        germany_vehicle_store: GermanyVehicleStore = GermanyVehicleStore()
        vehicle = germany_vehicle_store.order_vehicle('germany-toledo')

        self.assertIsInstance(vehicle, GermanyToledo)


if __name__ == '__main__':
    unittest.main()
