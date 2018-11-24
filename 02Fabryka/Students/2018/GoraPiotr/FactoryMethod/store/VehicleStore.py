from abc import ABC, abstractmethod


class VehicleStore(ABC):

    @abstractmethod
    def create_vehicle(self, vehicle_type):
        pass

    def order_vehicle(self, vehicle_type):
        vehicle = self.create_vehicle(vehicle_type)

        return vehicle
