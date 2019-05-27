from abc import ABC, abstractmethod

class ComputerBuilder(ABC):

    def get_computer(self):
        return self.computer

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
