import cProfile
import os
import pstats
import sys

sys.path.append(os.getcwd() + '/abstract_factory_extended')

from device_factories.economic_device_factory import EconomicDeviceFactory
from device_factories.game_device_factory import GameDeviceFactory
from device_factories.office_device_factory import OfficeDeviceFactory


def main():
    economic_device_factory = EconomicDeviceFactory()
    game_device_factory = GameDeviceFactory()
    office_device_factory = OfficeDeviceFactory()

    for i in range(2000):
        economic_computer = economic_device_factory.order_device("computer")
        economic_computer = economic_device_factory.order_device("laptop")
        economic_computer = economic_device_factory.order_device("mobile_phone")
        economic_computer = economic_device_factory.order_device("tablet")
        office_computer = office_device_factory.order_device("computer")
        office_computer = office_device_factory.order_device("laptop")
        office_computer = office_device_factory.order_device("mobile_phone")
        office_computer = office_device_factory.order_device("tablet")
        game_computer = game_device_factory.order_device("computer")
        game_computer = game_device_factory.order_device("laptop")
        game_computer = game_device_factory.order_device("mobile_phone")
        game_computer = game_device_factory.order_device("tablet")

if __name__ == "__main__":
    print("")
    cProfile.run('main()', 'restats')
    p = pstats.Stats('restats')
    p.strip_dirs().sort_stats(-1).print_stats()
    p.sort_stats('cumtime')
    p.print_stats()
