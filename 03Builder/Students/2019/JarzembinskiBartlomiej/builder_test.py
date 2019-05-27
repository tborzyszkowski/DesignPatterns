import cProfile
import os
import pstats
import sys

sys.path.append(os.getcwd() + '/builder')

from economic_computer_concrete_builder import EconomicComputerBuilder
from game_computer_concrete_builder import GameComputerBuilder
from office_computer_concrete_builder import OfficeComputerBuilder
from director import Director


def main():
    director = Director()

    for i in range(2000):
        builder = EconomicComputerBuilder()
        director.build(builder)
        economic_computer = builder.get_computer()
    
        builder = OfficeComputerBuilder()
        director.build(builder)
        office_computer = builder.get_computer()
    
        builder = GameComputerBuilder()
        director.build(builder)
        game_computer = builder.get_computer()

if __name__ == "__main__":
    print("")
    cProfile.run('main()', 'restats')
    p = pstats.Stats('restats')
    p.strip_dirs().sort_stats(-1).print_stats()
    p.sort_stats('cumtime')
    p.print_stats()
