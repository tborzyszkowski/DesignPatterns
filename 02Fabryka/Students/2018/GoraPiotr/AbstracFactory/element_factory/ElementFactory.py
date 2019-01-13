from abc import ABC, abstractmethod


class ElementFactory(ABC):

    @abstractmethod
    def get_motor(self)->str:
        pass

    @abstractmethod
    def get_sensors_list(self)-> []:
        pass