from economic_computer_concrete_builder import EconomicComputerBuilder
from game_computer_concrete_builder import GameComputerBuilder
from office_computer_concrete_builder import OfficeComputerBuilder
from director import Director


def main():
    director = Director()

    print("")

    economic_computer = director.build(EconomicComputerBuilder())
    economic_computer.print_info()

    print("")

    office_computer = director.build(OfficeComputerBuilder())
    office_computer.print_info()

    print("")

    game_computer = director.build(GameComputerBuilder())
    game_computer.print_info()

if __name__ == "__main__":
    main()
