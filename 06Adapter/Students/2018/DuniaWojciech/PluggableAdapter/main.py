""" Implementacja pluggable adaptera """
from math import pi
from abc import ABC, abstractmethod


class Square:
    def __new__(cls):
        return lambda x: 'Pole kwadratu o boku {}, wynosi: {}'.format(x, x*x)

    @staticmethod
    def perimeter():
        return lambda x: 'Obwod kwadratu o boku {}, wynosi: {}'.format(x, x * 4)


class Rectangle:
    def __new__(cls):
        return lambda x, y: 'Pole prostokata o bokach {} i {}, wynosi: {}'.format(x, y, x*y)


class Cube:
    def __new__(cls):
        return lambda x: 'Powierzchnia szescianu o boku {}, wynosi: {}'.format(x, x*x*6)


class Sphere:
    def __new__(cls):
        return lambda r: 'Powierzchnia sfery o promieniu {}, wynosi: {}'.format(r, round(4*pi*r**2, 2))


class Ball:
    def __new__(cls):
        return lambda r: 'Powierzchnia kuli o promieniu {}, wynosi: {}'.format(r, round(4*pi*r**2, 2))

    @staticmethod
    def volume():
        return lambda r: 'Objetosc kuli o promieniu {}, wynosi: {}'.format(r, round(4/3*pi*r**3, 2))


# Interfejs adaptera
class Target(ABC):
    @abstractmethod
    def calculate(self, *args):
        pass


# Adapter
class Adapter(Target):
    def __init__(self, adaptee):
        self._adaptee = adaptee

    def calculate(self, *args):
        print(self._adaptee(*args))


def main():
    adapter = Adapter(Square())
    adapter.calculate(2)

    adapter = Adapter(Square.perimeter())
    adapter.calculate(2)

    adapter = Adapter(Rectangle())
    adapter.calculate(2, 3)

    adapter = Adapter(Ball())
    adapter.calculate(2)

    adapter = Adapter(Ball.volume())
    adapter.calculate(1)

    adapter = Adapter(Sphere())
    adapter.calculate(3)

    adapter = Adapter(Cube())
    adapter.calculate(2)


if __name__ == "__main__":
    main()
