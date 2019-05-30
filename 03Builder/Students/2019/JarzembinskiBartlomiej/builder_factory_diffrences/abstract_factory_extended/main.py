from device_factories.economic_device_factory import EconomicDeviceFactory
from device_factories.game_device_factory import GameDeviceFactory
from device_factories.office_device_factory import OfficeDeviceFactory


def main():
    print("Economic devices:\n")

    device_factory = EconomicDeviceFactory()
    economic_device = device_factory.order_device("computer")
    economic_device.print_info()
    economic_device = device_factory.order_device("laptop")
    economic_device.print_info()
    economic_device = device_factory.order_device("mobile_phone")
    economic_device.print_info()
    economic_device = device_factory.order_device("tablet")
    economic_device.print_info()

    print("Office devices:\n")

    device_factory = OfficeDeviceFactory()
    office_device = device_factory.order_device("computer")
    office_device.print_info()
    office_device = device_factory.order_device("laptop")
    office_device.print_info()
    office_device = device_factory.order_device("mobile_phone")
    office_device.print_info()
    office_device = device_factory.order_device("tablet")
    office_device.print_info()

    print("Devices for gaming:\n")

    device_factory = GameDeviceFactory()
    game_device = device_factory.order_device("computer")
    game_device.print_info()
    game_device = device_factory.order_device("laptop")
    game_device.print_info()
    game_device = device_factory.order_device("mobile_phone")
    game_device.print_info()
    game_device = device_factory.order_device("tablet")
    game_device.print_info()

if __name__ == "__main__":
    main()
