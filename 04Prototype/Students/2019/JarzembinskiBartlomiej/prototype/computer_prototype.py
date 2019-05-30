from abc import ABC, abstractmethod
import copy

class ComputerPrototype(ABC):
    @abstractmethod
    def clone(self):
        pass


class Computer(ComputerPrototype):

    def __init__(self, case, motherboard, power_supply, cpu, gpu, drive, ram):
      self._case = case
      self._motherboard = motherboard
      self._power_supply = power_supply
      self._cpu = cpu
      self._gpu = gpu
      self._drive = drive
      self._ram = ram

    def clone(self):
        return copy.copy(self)