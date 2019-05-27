from computer.cpu_info import CpuInfo

class Cpu:

    def __init__(self, brand, generation, model_name, num_cores, frequency):
      self.info = CpuInfo(brand, generation, model_name)
      self.num_cores = num_cores
      self.frequency = frequency
