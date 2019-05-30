from computer_builder import ComputerBuilder


class Director:
    def build(self, computer_builder: ComputerBuilder):
        return computer_builder\
            .build_case()\
            .build_motherboard()\
            .build_power_supply()\
            .build_cpu()\
            .build_gpu()\
            .build_drive()\
            .build_ram()()
