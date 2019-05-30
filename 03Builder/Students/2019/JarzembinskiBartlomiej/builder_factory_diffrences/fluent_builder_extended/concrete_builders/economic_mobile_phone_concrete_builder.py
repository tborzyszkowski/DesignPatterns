from device import Device
from device_builder import DeviceBuilder

class EconomicMobilePhoneBuilder(DeviceBuilder):

    def __init__(self):
        self.device = Device("Economic mobile phone")

    def build_case(self):
        self.device._properties["case"] = "SilentiumPC Brutus M10 Pure Black"
        return self

    def build_motherboard(self):
        self.device._properties["motherboard"] = "Gigabyte B360M"
        return self

    def build_power_supply(self):
        self.device._properties["power supply"] = "Zasilacz ATX 400W be quiet!"
        return self

    def build_cpu(self):
        self.device._properties["cpu"] = "Intel Pentium Gold G5400 2x3.7 GHz"
        return self

    def build_gpu(self):
        self.device._properties["gpu"] = "Radeon HD6450 Sapphire 1024MB"
        return self

    def build_drive(self):
        self.device._properties["drive"] = "GoodRAM IRDM SSD 240GB"
        return self

    def build_ram(self):
        self.device._properties["ram"] = "DDR4 4GB 2666MHz Kingston HyperX Fury Black"
        return self
