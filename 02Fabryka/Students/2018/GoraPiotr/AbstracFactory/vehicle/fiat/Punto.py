from Factory.AbstracFactory.vehicle.fiat.Fiat import Fiat
from element_factory.ElementFactory import ElementFactory


class Punto(Fiat):

    def __init__(self, element_factory: ElementFactory):
        super(Punto, self).__init__(element_factory)

    def prepare(self):
        self.motor = self.element_factory.get_motor()
        self.sensors = self.element_factory.get_sensors_list()
