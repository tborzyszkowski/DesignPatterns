from components.case.silentium_armis import SilentiumArmis
from components.cpu.intel_i9 import IntelI9
from components.drive.adata_nvme import AdataNvme
from components.gpu.geforce_rtx2070 import GeforceRtx2070
from components.motherboard.gigabyte_z390 import GigabyteZ390
from components.power_supply.be_quiet_600 import BeQuiet600
from components.ram.goodram_16gb import Goodram16Gb
from components_factory.abstract_component_factory import ComponentFactory


class GameDeviceComponentFactory(ComponentFactory):

  def build_case(self):
    return SilentiumArmis()

  def build_motherboard(self):
    return GigabyteZ390()

  def build_power_supply(self):
    return BeQuiet600()

  def build_cpu(self):
    return IntelI9()

  def build_gpu(self):
    return GeforceRtx2070()

  def build_drive(self):
    return AdataNvme()

  def build_ram(self):
    return Goodram16Gb()