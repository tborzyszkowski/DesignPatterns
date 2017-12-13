class Director:
    __builder = None

    def setBuilder(self, builder):
        self.__builder = builder

    # Skladanie auta
    def getCar(self):
        car = Car()

        # Karoseria
        body = self.__builder.getBody()
        car.setBody(body)

        # Silnik
        engine = self.__builder.getEngine()
        car.setEngine(engine)

        # Kola
        i = 0
        while i < 4:
            wheel = self.__builder.getWheel()
            car.attachWheel(wheel)
            i += 1

        return car


# Finalny produkt
class Car:
    """ Samochod jest skladany przez Director z
    komponentow utworzyonych w Builder
    """
    def __init__(self):
        self.__wheels = []
        self.__engine = None
        self.__body = None

    def setBody(self, body):
        self.__body = body

    def attachWheel(self, wheel):
        self.__wheels.append(wheel)

    def setEngine(self, engine):
        self.__engine = engine

    def specification(self):
        print ("body: %s" % self.__body.shape)
        print ("engine horsepower: %d" % self.__engine.horsepower)
        print ("tire size: %d\'" % self.__wheels[0].size)


class Builder:
    def getWheel(self): pass
    def getEngine(self): pass
    def getBody(self): pass


class SportCar(Builder):
    def getWheel(self):
        wheel = Wheel()
        wheel.size = 22
        return wheel

    def getEngine(self):
        engine = Engine()
        engine.horsepower = 800
        return engine

    def getBody(self):
        body = Body()
        body.shape = "Coupe"
        return body


class VanBuilder(Builder):
    def getWheel(self):
        wheel = Wheel()
        wheel.size = 15
        return wheel

    def getEngine(self):
        engine = Engine()
        engine.horsepower = 90
        return engine

    def getBody(self):
        body = Body()
        body.shape = "VAN"
        return body


# Car parts
class Wheel:
    size = None


class Engine:
    horsepower = None


class Body:
    shape = None


def main():
    sportBuilder = SportCar()
    vanBuilder = VanBuilder()
    director = Director()

    # Auto sportowe
    print("Sport")
    director.setBuilder(sportBuilder)
    sport = director.getCar()
    sport.specification()

    print("-------------")

    # Auto transportowe
    print ("VAN")
    director.setBuilder(vanBuilder)
    van = director.getCar()
    van.specification()


if __name__ == "__main__":
    main()