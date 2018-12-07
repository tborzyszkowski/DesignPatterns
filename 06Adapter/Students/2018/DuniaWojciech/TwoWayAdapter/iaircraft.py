from abc import ABC, abstractmethod


class IAirCraft(ABC):
    @abstractmethod
    def take_off(self):
        pass

    @property
    def airborne(self):
        return self._airborne

    @airborne.setter
    def airborne(self, value):
        self._airborne = value

    @property
    def height(self):
        return self._height

    @height.setter
    def height(self, value):
        self._height = value
