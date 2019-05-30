from device import Device
from device_builder import DeviceBuilder


class GameLaptopBuilder(DeviceBuilder):

    def __init__(self):
        self.device = Device("Laptop for gaming")

    def build_case(self):
        self.device._properties["case"] = "SilentiumPC Armis AR7"
        return self

    def build_motherboard(self):
        self.device._properties["motherboard"] = "Gigabyte Z390 GAMING X"
        return self

    def build_power_supply(self):
        self.device._properties["power supply"] = "Zasilacz ATX 600W be quiet!"
        return self

    def build_cpu(self):
        self.device._properties["cpu"] = "Intel Core i9 9900K 8x3.6/5.0 GHz"
        return self

    def build_gpu(self):
        self.device._properties["gpu"] = "GeForce RTX2070 GIGABYTE GAMING 8G"
        return self

    def build_drive(self):
        self.device._properties["drive"] = "ADATA XPG SX8200 PRO 512GB NVMe M.2"
        return self

    def build_ram(self):
        self.device._properties["ram"] = "DDR4 16GB 3000MHz G.SKILL AEGIS"
        return self
