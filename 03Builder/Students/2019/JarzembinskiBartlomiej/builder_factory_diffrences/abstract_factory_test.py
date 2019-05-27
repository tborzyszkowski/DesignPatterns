import cProfile
import os
import pstats
import sys

sys.path.append(os.getcwd() + '/abstract_factory')

from computer_factories.economic_computer_factory import EconomicComputerFactory
from computer_factories.game_computer_factory import GameComputerFactory
from computer_factories.office_computer_factory import OfficeComputerFactory


def main():
    economic_computer_factory = EconomicComputerFactory()
    office_computer_factory = OfficeComputerFactory()
    game_computer_factory = GameComputerFactory()

    for i in range(2000):
        economic_computer = economic_computer_factory.create_computer()
        office_computer = office_computer_factory.create_computer()
        game_computer = game_computer_factory.create_computer()

if __name__ == "__main__":
    print("")
    cProfile.run('main()', 'restats')
    p = pstats.Stats('restats')
    p.strip_dirs().sort_stats(-1).print_stats()
    p.sort_stats('cumtime')
    p.print_stats()
