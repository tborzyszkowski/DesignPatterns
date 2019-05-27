from components_factory.game_computer_component_factory import GameComputerComponentFactory
from computer import Computer
from computer_factories.computer_factory import ComputerFactory


class GameComputerFactory(ComputerFactory):

  @staticmethod
  def create_computer():
    computer = None
    components_factory = GameComputerComponentFactory()
    computer = Computer()
    computer._name = "Computer for gaming"
    computer._case = components_factory.build_case()
    computer._cpu = components_factory.build_cpu()
    computer._drive = components_factory.build_drive()
    computer._gpu = components_factory.build_gpu()
    computer._motherboard = components_factory.build_motherboard()
    computer._power_supply = components_factory.build_power_supply()
    computer._ram = components_factory.build_ram()
    return computer