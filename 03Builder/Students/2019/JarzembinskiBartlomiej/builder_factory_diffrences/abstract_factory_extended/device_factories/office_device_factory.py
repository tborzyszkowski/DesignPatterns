from components_factory.office_device_component_factory import OfficeDeviceComponentFactory
from devices.computer import Computer
from devices.laptop import Laptop
from devices.mobile_phone import MobilePhone
from devices.tablet import Tablet
from device_factories.device_factory import DeviceFactory


class OfficeDeviceFactory(DeviceFactory):

  @staticmethod
  def create_device(device_type):
    device = None
    components_factory = OfficeDeviceComponentFactory()

    if device_type == "computer":
      device = Computer(components_factory)
      device._name = "Office computer"
    elif device_type == "laptop":
      device = Laptop(components_factory)
      device._name = "Office laptop"
    elif device_type == "tablet":
      device = Tablet(components_factory)
      device._name = "Office tablet"
    elif device_type == "mobile_phone":
      device = MobilePhone(components_factory)
      device._name = "Office mobile phone"
    else:
      None

    return device