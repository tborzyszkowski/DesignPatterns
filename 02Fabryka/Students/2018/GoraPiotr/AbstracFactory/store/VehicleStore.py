from abc import ABC, abstractmethod

from Factory.AbstracFactory.vehicle.Vehicle import Vehicle


class VehicleStore(ABC):

    @abstractmethod
    def create_vehicle(self, type: str):
        pass

    def order_vehicle(self, type: str):
        vehicle: Vehicle = self.create_vehicle(type)
        vehicle.prepare()

        return vehicle
