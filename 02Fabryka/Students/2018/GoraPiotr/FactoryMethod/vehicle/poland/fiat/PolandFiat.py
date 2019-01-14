from vehicle.Vehicle import Vehicle


class PolandFiat(Vehicle):

    def __init__(self):
        self.motor_amount = 1

    def move(self):
        return self.__class__.__name__ + ' move by wheels'

    def info(self):
        return 'Info about fiat'
