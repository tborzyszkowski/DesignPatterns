from economic_computer_concrete_builder import EconomicComputerBuilder
from game_computer_concrete_builder import GameComputerBuilder
from office_computer_concrete_builder import OfficeComputerBuilder
from director import Director


def main():
    director = Director()

    print("")

    builder = EconomicComputerBuilder()
    director.build(builder)
    economic_computer = builder.get_computer()
    economic_computer.show()

    print("")

    builder = OfficeComputerBuilder()
    director.build(builder)
    office_computer = builder.get_computer()
    office_computer.show()

    print("")

    builder = GameComputerBuilder()
    director.build(builder)
    game_computer = builder.get_computer()
    game_computer.show()

if __name__ == "__main__":
    main()
