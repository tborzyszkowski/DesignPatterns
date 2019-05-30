from components_factory.economic_device_component_factory import EconomicDeviceComponentFactory
from devices.computer import Computer
from devices.laptop import Laptop
from devices.mobile_phone import MobilePhone
from devices.tablet import Tablet
from device_factories.device_factory import DeviceFactory


class EconomicDeviceFactory(DeviceFactory):

  @staticmethod
  def create_device(device_type):
    device = None
    components_factory = EconomicDeviceComponentFactory()

    if device_type == "computer":
      device = Computer(components_factory)
      device._name = "Economic computer"
    elif device_type == "laptop":
      device = Laptop(components_factory)
      device._name = "Economic laptop"
    elif device_type == "tablet":
      device = Tablet(components_factory)
      device._name = "Economic tablet"
    elif device_type == "mobile_phone":
      device = MobilePhone(components_factory)
      device._name = "Economic mobile phone"
    else:
      None

    return device