from abc import ABC, abstractmethod


class Vehicle(ABC):

    @abstractmethod
    def move(self):
        pass

    @abstractmethod
    def info(self):
        pass
