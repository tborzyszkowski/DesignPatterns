from abc import ABC, abstractmethod

class Device:

  def __init__(self):
    self._name = None
    self._case = None
    self._cpu = None
    self._drive = None
    self._gpu = None
    self._motherboard = None
    self._power_supply = None
    self._ram = None

  @abstractmethod
  def prepare(self):
    pass

  def print_info(self):
    print(f"ID: {id(self)}")
    print(f"Type: {self._name}")
    print(f"- case: {self._case}",
          f"\n- cpu: {self._cpu}",
          f"\n- drive: {self._drive}",
          f"\n- gpu: {self._gpu}",
          f"\n- motherboard: {self._motherboard}",
          f"\n- power_supply: {self._power_supply}",
          f"\n- ram: {self._ram}")
    print("")