from abc import ABC, abstractmethod


class ISeaCraft(ABC):
    def __init__(self):
        self.speed = 0

    @abstractmethod
    def increase_revs(self):
        pass

    @property
    def speed(self):
        return self._speed

    @speed.setter
    def speed(self, value):
        self._speed = value
