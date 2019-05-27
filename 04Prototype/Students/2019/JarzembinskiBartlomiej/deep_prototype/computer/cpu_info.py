from computer.cpu_model import CpuModel

class CpuInfo:

    def __init__(self, brand, generation, model_name):
      self.brand = brand
      self.model = CpuModel(generation, model_name)
