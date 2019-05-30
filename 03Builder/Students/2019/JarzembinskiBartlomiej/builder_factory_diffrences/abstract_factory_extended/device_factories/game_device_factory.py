from components_factory.game_device_component_factory import GameDeviceComponentFactory
from devices.computer import Computer
from devices.laptop import Laptop
from devices.mobile_phone import MobilePhone
from devices.tablet import Tablet
from device_factories.device_factory import DeviceFactory


class GameDeviceFactory(DeviceFactory):

  @staticmethod
  def create_device(device_type):
    device = None
    components_factory = GameDeviceComponentFactory()

    if device_type == "computer":
      device = Computer(components_factory)
      device._name = "Computer for gaming"
    elif device_type == "laptop":
      device = Laptop(components_factory)
      device._name = "Laptop for gaming"
    elif device_type == "tablet":
      device = Tablet(components_factory)
      device._name = "Tablet for gaming"
    elif device_type == "mobile_phone":
      device = MobilePhone(components_factory)
      device._name = "Mobile phone for gaming"
    else:
      None

    return device