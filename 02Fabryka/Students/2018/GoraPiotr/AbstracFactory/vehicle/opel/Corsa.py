from element_factory.ElementFactory import ElementFactory
from vehicle.opel.Opel import Opel


class Corsa(Opel):

    def __init__(self, element_factory: ElementFactory):
        super(Corsa, self).__init__(element_factory)

    def prepare(self):
        self.motor = self.element_factory.get_motor()
        self.sensors = self.element_factory.get_sensors_list()
