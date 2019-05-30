from abc import ABC, abstractmethod
from threading import Lock


class ComponentFactory(ABC):
  _instances = {}
  _threading_lock = Lock()

  def __new__(cls):
    if type(object.__new__(cls)).__name__ not in cls._instances:
      with cls._threading_lock:
        if type(object.__new__(cls)).__name__ not in cls._instances:
          cls._instances[type(object.__new__(cls)).__name__] = object.__new__(cls)
    return cls._instances[type(object.__new__(cls)).__name__]

  @abstractmethod
  def build_case(self):
    pass

  @abstractmethod
  def build_motherboard(self):
    pass

  @abstractmethod
  def build_power_supply(self):
    pass

  @abstractmethod
  def build_cpu(self):
    pass

  @abstractmethod
  def build_gpu(self):
    pass

  @abstractmethod
  def build_drive(self):
    pass

  @abstractmethod
  def build_ram(self):
    pass