from element.sensors.Sensors import Sensors


class CheapSensors(Sensors):

    def __init__(self):
        self.sensors_list = []
        self.sensors_list.append('Airbag sensors')
        self.sensors_list.append('Automatic transmission speed sensor')
        self.sensors_list.append('Camshaft position sensor')

        super(CheapSensors, self).__init__(self.sensors_list)
