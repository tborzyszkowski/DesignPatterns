from computer.cpu import Cpu
from computer_base_prototype import BasePrototype


class Prototype(BasePrototype):

    def __init__(self, case, motherboard, power_supply, cpu_brand, cpu_generation, cpu_model_name, cpu_num_cores, cpu_frequency, gpu, drive, ram):
      self.case = case
      self.motherboard = motherboard
      self.power_supply = power_supply
      self.cpu = Cpu(cpu_brand, cpu_generation, cpu_model_name, cpu_num_cores, cpu_frequency)
      self.gpu = gpu
      self.drive = drive
      self.ram = ram
