import unittest

from element_factory.GermanyElementFactory import GermanyElementFactory
from element_factory.PolandElementFactory import PolandElementFactory

from store.GermanyVehicleStore import GermanyVehicleStore
from store.PolandVehicleStore import PolandVehicleStore
from vehicle.fiat.Punto import Punto


class TestAbstractFactory(unittest.TestCase):

    def test_create_vehicle_by_poland_store(self):
        poland_vehicle_store: PolandVehicleStore = PolandVehicleStore()

        vehicle = poland_vehicle_store.order_vehicle('punto')

        self.assertIsInstance(vehicle, Punto)

    def test_create_vehicle_by_germany_store(self):
        germany_vehicle_store: GermanyVehicleStore = GermanyVehicleStore()

        vehicle = germany_vehicle_store.order_vehicle('punto')

        self.assertIsInstance(vehicle, Punto)

    def test_check_properties_vehicle_by_germany_and_poland(self):
        poland_vehicle_store: PolandVehicleStore = PolandVehicleStore()
        poland_vehicle = poland_vehicle_store.order_vehicle('punto')

        germany_vehicle_store: GermanyVehicleStore = GermanyVehicleStore()
        germany_vehicle = germany_vehicle_store.order_vehicle('punto')

        if GermanyElementFactory().get_motor() == PolandElementFactory().get_motor():
            self.assertEqual(germany_vehicle.motor, poland_vehicle.motor)
        else:
            self.assertEqual(germany_vehicle.motor, GermanyElementFactory().get_motor())
            self.assertEqual(poland_vehicle.motor, PolandElementFactory().get_motor())
            self.assertNotEqual(germany_vehicle.motor, poland_vehicle.motor)

    def test_create_vehicle_seat_by_german_store(self):
        germany_vehicle_store: GermanyVehicleStore = GermanyVehicleStore()

        vehicle = germany_vehicle_store.order_vehicle('ibiza')

        self.assertIsInstance(vehicle, Ibiza)


if __name__ == '__main__':
    unittest.main()
