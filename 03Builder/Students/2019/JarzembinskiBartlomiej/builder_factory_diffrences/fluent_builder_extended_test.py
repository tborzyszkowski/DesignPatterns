import cProfile
import os
import pstats
import sys

sys.path.append(os.getcwd() + '/fluent_builder_extended')

from concrete_builders.economic_computer_concrete_builder import EconomicComputerBuilder
from concrete_builders.economic_laptop_concrete_builder import EconomicLaptopBuilder
from concrete_builders.economic_mobile_phone_concrete_builder import EconomicMobilePhoneBuilder
from concrete_builders.economic_tablet_concrete_builder import EconomicTabletBuilder
from concrete_builders.game_computer_concrete_builder import GameComputerBuilder
from concrete_builders.game_laptop_concrete_builder import GameLaptopBuilder
from concrete_builders.game_mobile_phone_concrete_builder import GameMobilePhoneBuilder
from concrete_builders.game_tablet_concrete_builder import GameTabletBuilder
from concrete_builders.office_computer_concrete_builder import OfficeComputerBuilder
from concrete_builders.office_laptop_concrete_builder import OfficeLaptopBuilder
from concrete_builders.office_mobile_phone_concrete_builder import OfficeMobilePhoneBuilder
from concrete_builders.office_tablet_concrete_builder import OfficeTabletBuilder
from director import Director


def main():
    director = Director()

    for i in range(2000):
        economic_device = director.build(EconomicComputerBuilder())
        economic_device = director.build(EconomicLaptopBuilder())
        economic_device = director.build(EconomicMobilePhoneBuilder())
        economic_device = director.build(EconomicTabletBuilder())
        office_device = director.build(OfficeComputerBuilder())
        office_device = director.build(OfficeLaptopBuilder())
        office_device = director.build(OfficeMobilePhoneBuilder())
        office_device = director.build(OfficeTabletBuilder())
        game_device = director.build(GameComputerBuilder())
        game_device = director.build(GameLaptopBuilder())
        game_device = director.build(GameMobilePhoneBuilder())
        game_device = director.build(GameTabletBuilder())

if __name__ == "__main__":
    print("")
    cProfile.run('main()', 'restats')
    p = pstats.Stats('restats')
    p.strip_dirs().sort_stats(-1).print_stats()
    p.sort_stats('cumtime')
    p.print_stats()
