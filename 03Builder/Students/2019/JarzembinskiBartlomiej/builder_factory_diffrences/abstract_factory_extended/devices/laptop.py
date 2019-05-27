from devices.device import Device

class Laptop(Device):

  def __init__(self, components_factory):
    self._components_factory = components_factory

  def prepare(self):
    self._case = self._components_factory.build_case()
    self._cpu = self._components_factory.build_cpu()
    self._drive = self._components_factory.build_drive()
    self._gpu = self._components_factory.build_gpu()
    self._motherboard = self._components_factory.build_motherboard()
    self._power_supply = self._components_factory.build_power_supply()
    self._ram = self._components_factory.build_ram()
