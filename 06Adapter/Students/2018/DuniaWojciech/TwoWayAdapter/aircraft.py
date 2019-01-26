from iaircraft import IAirCraft


class AirCraft(IAirCraft):
    def __init__(self):
        self.height = 0
        self.airborne = False

    def take_off(self):
        print("Aircraft engine takeoff")
        self.height = 200
        self.airborne = True

