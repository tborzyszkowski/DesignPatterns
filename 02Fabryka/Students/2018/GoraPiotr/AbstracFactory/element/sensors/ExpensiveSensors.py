from element.sensors.Sensors import Sensors


class ExpensiveSensors(Sensors):

    def __init__(self):
        self.sensors_list = []
        self.sensors_list.append('Airbag sensors')
        self.sensors_list.append('Automatic transmission speed sensor')
        self.sensors_list.append('Camshaft position sensor')
        self.sensors_list.append('Crankshaft position sensor')
        self.sensors_list.append('Coolant temperature sensor')
        self.sensors_list.append('Fuel level sensor')
        self.sensors_list.append('Fuel pressure sensor')
        self.sensors_list.append('Knock sensor')
        self.sensors_list.append('Light sensor')
        self.sensors_list.append('MAP sensor')

        super(__class__, self).__init__(self.sensors_list)
