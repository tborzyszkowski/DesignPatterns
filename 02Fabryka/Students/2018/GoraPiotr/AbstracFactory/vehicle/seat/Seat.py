from element_factory.ElementFactory import ElementFactory
from vehicle.Vehicle import Vehicle


class Seat(Vehicle):

    def __init__(self, element_factory: ElementFactory):
        self.element_factory = element_factory
        super(Seat, self).__init__()

    def move(self):
        return self.__class__.__name__ + ' move by wheels'

    def info(self):
        return 'Info about seat'
