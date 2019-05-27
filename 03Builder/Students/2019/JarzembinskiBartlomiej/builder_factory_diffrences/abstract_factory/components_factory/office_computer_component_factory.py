from components.case.cooler import Cooler
from components.cpu.intel_i5 import IntelI5
from components.drive.adata import Adata
from components.gpu.geforce_gt1030 import GeforceGt1030
from components.motherboard.gigabyte_ga_b360m import GigabyteGaB360m
from components.power_supply.be_quiet_420 import BeQuiet420
from components.ram.goodram_8gb import Goodram8Gb
from components_factory.abstract_component_factory import ComponentFactory


class OfficeComputerComponentFactory(ComponentFactory):

  def build_case(self):
    return Cooler()

  def build_motherboard(self):
    return GigabyteGaB360m()

  def build_power_supply(self):
    return BeQuiet420()

  def build_cpu(self):
    return IntelI5()

  def build_gpu(self):
    return GeforceGt1030()

  def build_drive(self):
    return Adata()

  def build_ram(self):
    return Goodram8Gb()