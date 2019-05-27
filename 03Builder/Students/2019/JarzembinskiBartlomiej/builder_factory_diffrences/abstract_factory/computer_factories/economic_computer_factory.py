from components_factory.economic_computer_component_factory import EconomicComputerComponentFactory
from computer import Computer
from computer_factories.computer_factory import ComputerFactory


class EconomicComputerFactory(ComputerFactory):

  @staticmethod
  def create_computer():
    computer = None
    components_factory = EconomicComputerComponentFactory()
    computer = Computer()
    computer._name = "Economic computer"
    computer._case = components_factory.build_case()
    computer._cpu = components_factory.build_cpu()
    computer._drive = components_factory.build_drive()
    computer._gpu = components_factory.build_gpu()
    computer._motherboard = components_factory.build_motherboard()
    computer._power_supply = components_factory.build_power_supply()
    computer._ram = components_factory.build_ram()
    return computer