from computer import Computer
from computer_builder import ComputerBuilder

class EconomicComputerBuilder(ComputerBuilder):

    def __init__(self):
        self.computer = Computer("Economic computer")

    def build_case(self):
        self.computer._properties["case"] = "SilentiumPC Brutus M10 Pure Black"

    def build_motherboard(self):
        self.computer._properties["motherboard"] = "Gigabyte B360M"

    def build_power_supply(self):
        self.computer._properties["power supply"] = "Zasilacz ATX 400W be quiet!"

    def build_cpu(self):
        self.computer._properties["cpu"] = "Intel Pentium Gold G5400 2x3.7 GHz"

    def build_gpu(self):
        self.computer._properties["gpu"] = "Radeon HD6450 Sapphire 1024MB"

    def build_drive(self):
        self.computer._properties["drive"] = "GoodRAM IRDM SSD 240GB"

    def build_ram(self):
        self.computer._properties["ram"] = "DDR4 4GB 2666MHz Kingston HyperX Fury Black"
