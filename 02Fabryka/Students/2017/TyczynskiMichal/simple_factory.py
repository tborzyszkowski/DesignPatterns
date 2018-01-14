import random

class Car(object):
    def factory(type):
        if type == "BMW": return BMW()
        if type == "Audi": return Audi()
        assert 0, "Bad shape creation: " + type


class BMW(Car):
    def model(self): print("BMW e36")
    def przebieg(self): print("przebieg 223 123")

class Audi(Car):
    def model(self): print("Audi A3")
    def przebieg(self): print("przebieg 145 007")

def shapeNameGen(n):
    types = Car.__subclasses__()
    print(types)
    for i in range(n):
        yield random.choice(types).__name__

cars = [ Car.factory(i) for i in shapeNameGen(3)]

for car in cars:
    car.model()
    car.przebieg()