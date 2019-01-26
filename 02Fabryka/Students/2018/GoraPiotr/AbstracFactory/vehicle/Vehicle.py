from abc import ABC, abstractmethod


class Vehicle(ABC):

    def __init__(self):
        self.motor = None
        self.sensors = None

    @abstractmethod
    def prepare(self):
        pass

    @abstractmethod
    def move(self):
        pass

    @abstractmethod
    def info(self):
        pass
