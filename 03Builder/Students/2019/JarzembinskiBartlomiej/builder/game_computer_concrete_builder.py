from computer import Computer
from computer_builder import ComputerBuilder


class GameComputerBuilder(ComputerBuilder):

    def __init__(self):
        self.computer = Computer("Game computer")

    def build_case(self):
        self.computer._properties["case"] = "SilentiumPC Armis AR7"

    def build_motherboard(self):
        self.computer._properties["motherboard"] = "Gigabyte Z390 GAMING X"

    def build_power_supply(self):
        self.computer._properties["power supply"] = "Zasilacz ATX 600W be quiet!"

    def build_cpu(self):
        self.computer._properties["cpu"] = "Intel Core i9 9900K 8x3.6/5.0 GHz"

    def build_gpu(self):
        self.computer._properties["gpu"] = "GeForce RTX2070 GIGABYTE GAMING 8G"

    def build_drive(self):
        self.computer._properties["drive"] = "ADATA XPG SX8200 PRO 512GB NVMe M.2"

    def build_ram(self):
        self.computer._properties["ram"] = "DDR4 16GB 3000MHz G.SKILL AEGIS"
