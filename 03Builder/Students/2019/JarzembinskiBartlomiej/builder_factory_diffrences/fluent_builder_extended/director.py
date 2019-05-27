from device_builder import DeviceBuilder


class Director:
    def build(self, device_builder: DeviceBuilder):
        return device_builder\
            .build_case()\
            .build_motherboard()\
            .build_power_supply()\
            .build_cpu()\
            .build_gpu()\
            .build_drive()\
            .build_ram()()
