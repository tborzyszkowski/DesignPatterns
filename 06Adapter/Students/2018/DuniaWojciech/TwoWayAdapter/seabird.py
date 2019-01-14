from iaircraft import IAirCraft
from seacraft import SeaCraft


class SeaBird(SeaCraft, IAirCraft):
    def __init__(self):
        self.airborne = False
        self.height = 0
        self.speed = 0

    @IAirCraft.airborne.getter
    def airborne(self):
        return self.height > 50

    def take_off(self):
        while not self.airborne:
            self.increase_revs()

    def increase_revs(self):
        super().increase_revs()
        if self.speed > 40:
            self.height += 100
