from computer_builder import ComputerBuilder


class Director:
    def build(self, computer_builder: ComputerBuilder):
        computer_builder.build_case()
        computer_builder.build_motherboard()
        computer_builder.build_power_supply()
        computer_builder.build_cpu()
        computer_builder.build_gpu()
        computer_builder.build_drive()
        computer_builder.build_ram()
