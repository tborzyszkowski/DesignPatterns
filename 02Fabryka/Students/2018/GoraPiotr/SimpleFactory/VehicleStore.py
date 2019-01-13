class VehicleStore:

    def __init__(self, factory):
        self.factory = factory

    def order_vehicle(self, vehicle_type):
        vehicle = self.factory.create_vehicle(vehicle_type)

        return vehicle
