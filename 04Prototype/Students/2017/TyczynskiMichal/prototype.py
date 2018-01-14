import copy

class Prototype:
    nation = None
    model = None

    def clone(self):
        pass

    def getNation(self):
        return self.nation

    def getModel(self):
        return self.model

class TankGerman(Prototype):
    def __init__(self, model):
        self.nation = "Germany"
        self.model = model

    def clone(self):
        return copy.copy(self)


class TankAmerican(Prototype):
    def __init__(self, model):
        self.nation = "USA"
        self.model = model

    def clone(self):
        return copy.deepcopy(self)


class TankFactory:
    tank1 = None
    tank2 = None
    tank3 = None
    tank4 = None

    @staticmethod
    def initialize():
        TankFactory.tank1 = TankGerman("TigerII")
        TankFactory.tank2 = TankGerman("TigerI")
        TankFactory.tank3 = TankAmerican("Pershing")
        TankFactory.tank4 = TankAmerican("Patton")

    @staticmethod
    def getTiger2():
        return TankFactory.tank1.clone()

    @staticmethod
    def getTiger1():
        return TankFactory.tank2.clone()

    @staticmethod
    def getPershing():
        return TankFactory.tank3.clone()

    @staticmethod
    def getPatton():
        return TankFactory.tank4.clone()


def main():
    TankFactory.initialize()

    instance = TankFactory.getTiger2()
    print("%s: %s" % (instance.getNation(), instance.getModel()))
    print(instance)

    instance = TankFactory.getTiger1()
    print("%s: %s" % (instance.getNation(), instance.getModel()))
    print(instance)

    instance = TankFactory.getPershing()
    print("%s: %s" % (instance.getNation(), instance.getModel()))
    print(instance)

    instance = TankFactory.getPatton()
    print("%s: %s" % (instance.getNation(), instance.getModel()))
    print(instance)


if __name__ == "__main__":
    main()