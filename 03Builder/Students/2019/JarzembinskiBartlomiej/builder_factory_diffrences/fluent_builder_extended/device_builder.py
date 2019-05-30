from abc import ABC, abstractmethod

class DeviceBuilder(ABC):

    def __call__(self):
        return self.device

    @abstractmethod
    def build_case(self):
        pass

    @abstractmethod
    def build_motherboard(self):
        pass

    @abstractmethod
    def build_power_supply(self):
        pass

    @abstractmethod
    def build_cpu(self):
        pass

    @abstractmethod
    def build_gpu(self):
        pass

    @abstractmethod
    def build_drive(self):
        pass

    @abstractmethod
    def build_ram(self):
        pass
