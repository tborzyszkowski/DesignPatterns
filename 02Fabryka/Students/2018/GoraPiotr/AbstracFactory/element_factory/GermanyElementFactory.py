from element.motor.Diesel import Diesel
from element.sensors.ExpensiveSensors import ExpensiveSensors
from element_factory.ElementFactory import ElementFactory


class GermanyElementFactory(ElementFactory):

    def get_sensors_list(self) -> []:
        return ExpensiveSensors().get_sensors_list()

    def get_motor(self) -> str:
        return Diesel().get_motor()
