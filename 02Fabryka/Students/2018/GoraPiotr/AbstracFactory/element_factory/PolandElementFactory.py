from Factory.AbstracFactory.element_factory.ElementFactory import ElementFactory
from element.motor.Engine import Engine
from element.sensors.CheapSensors import CheapSensors


class PolandElementFactory(ElementFactory):

    def get_sensors_list(self) -> []:
        return CheapSensors().get_sensors_list()

    def get_motor(self) -> str:
        return Engine().get_motor()
