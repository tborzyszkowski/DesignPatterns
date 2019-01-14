from iseacraft import ISeaCraft
from iaircraft import IAirCraft
from aircraft import AirCraft


class SeaBirdAir(AirCraft, ISeaCraft):
    def __init__(self):
        self.airborne = False
        self.height = 0
        self.speed = 0

    def airborne(self):
        return self.airborne

    def take_off(self):
        super().take_off()
        if self.airborne:
            self.speed = 80

    def increase_revs(self):
        self.speed += 10
        print("Seacraft engine increases revs to ", self.speed, " knots")
        if self.speed > 70:
            self.take_off()
