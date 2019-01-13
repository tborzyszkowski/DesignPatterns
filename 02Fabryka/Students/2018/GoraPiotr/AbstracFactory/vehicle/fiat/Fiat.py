from Factory.AbstracFactory.vehicle.Vehicle import Vehicle
from element_factory.ElementFactory import ElementFactory


class Fiat(Vehicle):

    def __init__(self, element_factory: ElementFactory):
        self.element_factory = element_factory
        super(Fiat, self).__init__()

    def prepare(self):
        pass

    def move(self):
        return self.__class__.__name__ + ' move by wheels'

    def info(self):
        return 'Info about fiat'
