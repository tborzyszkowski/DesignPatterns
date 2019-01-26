from iseacraft import ISeaCraft


class SeaCraft(ISeaCraft):
    def __init__(self):
        self.speed = 0

    def increase_revs(self):
        self.speed += 10
        print("Seacraft engine increases revs to ", self.speed, " knots")
