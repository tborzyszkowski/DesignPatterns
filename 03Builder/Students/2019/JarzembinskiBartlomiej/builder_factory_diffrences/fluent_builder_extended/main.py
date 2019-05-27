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

    print("Economic devices:\n")

    economic_device = director.build(EconomicComputerBuilder())
    economic_device.print_info()
    economic_device = director.build(EconomicLaptopBuilder())
    economic_device.print_info()
    economic_device = director.build(EconomicMobilePhoneBuilder())
    economic_device.print_info()
    economic_device = director.build(EconomicTabletBuilder())
    economic_device.print_info()

    print("Office devices:\n")

    office_device = director.build(OfficeComputerBuilder())
    office_device.print_info()
    office_device = director.build(OfficeLaptopBuilder())
    office_device.print_info()
    office_device = director.build(OfficeMobilePhoneBuilder())
    office_device.print_info()
    office_device = director.build(OfficeTabletBuilder())
    office_device.print_info()

    print("Devices for gaming:\n")

    game_device = director.build(GameComputerBuilder())
    game_device.print_info()
    game_device = director.build(GameLaptopBuilder())
    game_device.print_info()
    game_device = director.build(GameMobilePhoneBuilder())
    game_device.print_info()
    game_device = director.build(GameTabletBuilder())
    game_device.print_info()

if __name__ == "__main__":
    main()
