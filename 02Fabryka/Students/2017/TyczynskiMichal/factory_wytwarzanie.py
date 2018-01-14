from abc import ABC, abstractmethod

class CarsSeller():
    def __init__(self):
        self.berStore = BerlinCarStore()
        self.chicagoStore = ChicagoCarStore()

        car = self.berStore.assemblyCar("Audi")
        print("Hans bought " + car.getType() + "\n")

        car = self.chicagoStore.assemblyCar("Ford")
        print("Jack ordered a " + car.getType() + "\n")


class CarStore(ABC):
    @abstractmethod
    def createCar(self, item):
        pass

    def assemblyCar(self, type):
        self.car = self.createCar(type)
        print("--- Assembling a " + self.car.getType() + " car ---")
        self.car.assemble()
        self.car.paintCar()
        self.car.ship()
        self.car.sell()
        return self.car

class Car(ABC):
    def __init__(self):
        self.body = ''
        self.topSpeed = ''
        self.paint = ''
        self.price = ''

    def assemble(self):
        print("Assembling " + self.body)

    def paintCar(self):
        print ("Painting car.")

    def ship(self):
        print ("Shipping to destination country")

    def sell(self):
        print ("Ready for pickup.")

    def getType(self):
        return self.body

# Chicago
class ChicagoCarStore(CarStore):
    def __init__(self):
        pass

    def createCar(self, item):
        if item == "BMW":
            return ChicagoEuropeanCar()
        elif item == "Ford":
            return ChicagoAmericanCar()
        else:
            return None

class ChicagoEuropeanCar(Car):
    def __init__(self):
        self.body = 'SEDAN'
        self.topSpeed = '300'
        self.paint = 'red'
        self.price = '300 000'

class ChicagoAmericanCar(Car):
    def __init__(self):
        self.body = 'PICKUP'
        self.topSpeed = '200'
        self.paint = 'green'
        self.price = '100 000'

    def ship(self):
        print ("Local Car, no need to ship abroad. using local shipment.")

# Berlin
class BerlinCarStore(CarStore):
    def __init__(self):
        pass

    def createCar(self, item):
        if item == "Audi":
            return BerlinEuropeanCar()
        elif item == "Corvette":
            return BerlinAmericanCar()
        else:
            return None


class BerlinEuropeanCar(Car):
    def __init__(self):
        self.body = 'SUV'
        self.topSpeed = '220'
        self.paint = 'yellow'
        self.price = '223 000'

    def ship(self):
        print ("Local Car, no need to ship abroad. using local shipment.")

class BerlinAmericanCar(Car):
    def __init__(self):
        self.body = 'SEDAN'
        self.topSpeed = '200'
        self.paint = 'blue'
        self.price = '110 000'

cars = CarsSeller()