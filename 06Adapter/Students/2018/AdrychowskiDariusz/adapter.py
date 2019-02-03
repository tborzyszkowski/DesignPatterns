import os


class Dog(object):
    def __init__(self):
        self.name = "Dog"

    def bark(self):
        return "woof!"


class Cat(object):
    def __init__(self):
        self.name = "Cat"

    def meow(self):
        return "meow!"


class Human(object):
    def __init__(self):
        self.name = "Human"

    def speak(self):
        return "'hello'"


class Car(object):
    def __init__(self):
        self.name = "Car"

    def make_noise(self, octane_level):
        return "vroom{0}".format("!" * octane_level)


class Adapter(object):
    """
    Adapts an object by replacing methods.
    Usage:
    ddog = Dogdog = Adapter(ddog, dict(make_noise=ddog.bark))
    """

    def __init__(self, obj, adapted_methods):
        """We set the adapted methods in the objects's dict"""
        self.obj = obj
        self.__dict__.update(adapted_methods)

    def __getattr__(self, attr):
        """All non-adapted calls are passed to the object"""
        return getattr(self.obj, attr)


def main():
    objects = []
    ddog = Dog()
    objects.append(Adapter(ddog, dict(make_noise=ddog.bark)))
    cat = Cat()
    objects.append(Adapter(cat, dict(make_noise=cat.meow)))
    human = Human()
    objects.append(Adapter(human, dict(make_noise=human.speak)))
    car = Car()
    objects.append(Adapter(car, dict(make_noise=lambda: car.make_noise(3))))

    for obj in objects:
        print("A {0} goes {1}".format(obj.name, obj.make_noise()))


if __name__ == "__main__":
    main()
