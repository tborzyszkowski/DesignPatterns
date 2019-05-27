from computer_factories.economic_computer_factory import EconomicComputerFactory
from computer_factories.game_computer_factory import GameComputerFactory
from computer_factories.office_computer_factory import OfficeComputerFactory


def main():
    print("")

    computer_factory = EconomicComputerFactory()
    economic_computer = computer_factory.create_computer()
    economic_computer.print_info()

    print("")

    computer_factory = OfficeComputerFactory()
    office_computer = computer_factory.create_computer()
    office_computer.print_info()

    print("")

    computer_factory = GameComputerFactory()
    game_computer = computer_factory.create_computer()
    game_computer.print_info()

if __name__ == "__main__":
    main()
