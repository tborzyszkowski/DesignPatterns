from components.case.silentium_brutus import SilentiumBrutus
from components.cpu.intel_pentium import IntelPentium
from components.drive.goodram import GoodRam
from components.gpu.radeon import Radeon
from components.motherboard.gigabyte_b360m import GigabyteB360m
from components.power_supply.be_quiet_400 import BeQuiet400
from components.ram.kingston_4gb import Kingston4Gb
from components_factory.abstract_component_factory import ComponentFactory


class EconomicDeviceComponentFactory(ComponentFactory):

  def build_case(self):
    return SilentiumBrutus()

  def build_motherboard(self):
    return GigabyteB360m()

  def build_power_supply(self):
    return BeQuiet400()

  def build_cpu(self):
    return IntelPentium()

  def build_gpu(self):
    return Radeon()

  def build_drive(self):
    return GoodRam()

  def build_ram(self):
    return Kingston4Gb()