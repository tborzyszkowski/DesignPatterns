from computer import Computer
from computer_builder import ComputerBuilder


class OfficeComputerBuilder(ComputerBuilder):

    def __init__(self):
        self.computer = Computer("Office computer")

    def build_case(self):
        self.computer._properties["case"] = "Cooler Master Elite 342"

    def build_motherboard(self):
        self.computer._properties["motherboard"] = "Gigabyte GA-B360M"

    def build_power_supply(self):
        self.computer._properties["power supply"] = "Zasilacz ATX 420W be quiet!"

    def build_cpu(self):
        self.computer._properties["cpu"] = "Intel Core i5 9400F 6x2.9/4.1 GHz"

    def build_gpu(self):
        self.computer._properties["gpu"] = "GeForce GT1030 Gigabyte 2GB"

    def build_drive(self):
        self.computer._properties["drive"] = "ADATA 512GB SSD"

    def build_ram(self):
        self.computer._properties["ram"] = "GOODRAM Pamięć IRDM X DDR4 8GB 3000MHz"
