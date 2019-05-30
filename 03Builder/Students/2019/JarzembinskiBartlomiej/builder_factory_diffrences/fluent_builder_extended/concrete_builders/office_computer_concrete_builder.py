from device import Device
from device_builder import DeviceBuilder


class OfficeComputerBuilder(DeviceBuilder):

    def __init__(self):
        self.device = Device("Office computer")

    def build_case(self):
        self.device._properties["case"] = "Cooler Master Elite 342"
        return self

    def build_motherboard(self):
        self.device._properties["motherboard"] = "Gigabyte GA-B360M"
        return self

    def build_power_supply(self):
        self.device._properties["power supply"] = "Zasilacz ATX 420W be quiet!"
        return self

    def build_cpu(self):
        self.device._properties["cpu"] = "Intel Core i5 9400F 6x2.9/4.1 GHz"
        return self

    def build_gpu(self):
        self.device._properties["gpu"] = "GeForce GT1030 Gigabyte 2GB"
        return self

    def build_drive(self):
        self.device._properties["drive"] = "ADATA 512GB SSD"
        return self

    def build_ram(self):
        self.device._properties["ram"] = "GOODRAM Pamięć IRDM X DDR4 8GB 3000MHz"
        return self
