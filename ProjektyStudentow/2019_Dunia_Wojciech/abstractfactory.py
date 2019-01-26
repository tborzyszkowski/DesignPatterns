# Copyright (C) 2019 Wojciech Dunia
# w.dunia@gmail.com

from abc import ABC, abstractmethod
import threading
from objects import Ship


class ItemsAbstractFactory(ABC):
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    @abstractmethod
    def create_body(self): pass

    @abstractmethod
    def create_left_wing(self): pass

    @abstractmethod
    def create_right_wing(self): pass

    @abstractmethod
    def create_right_rear_wing(self): pass

    @abstractmethod
    def create_left_rear_wing(self): pass

    @abstractmethod
    def create_weapon(self): pass


class EnemyAbstractFactory(ABC):
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls, items_factory: ItemsAbstractFactory):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def __init__(self, items_factory: ItemsAbstractFactory):
        self.items_factory = items_factory
        self.enemy = {}

    @abstractmethod
    def create_enemy(self): pass

    def get_enemy(self):
        return self.enemy


class PlaneItemsFactory(ItemsAbstractFactory):
    """ Plane items concrete factory """
    def create_body(self):
        return [[30, 10], [20, 20], [20, 50], [40, 50], [40, 20]]

    def create_right_rear_wing(self):
        return [[0, 0]]

    def create_left_rear_wing(self):
        return [[0, 0]]

    def create_left_wing(self):
        return [[20, 40], [10, 50], [20, 50]]

    def create_right_wing(self):
        return [[40, 40], [40, 50], [50, 50]]

    def create_weapon(self):
        return [[0, 0]]


class Enemy1ItemsFactory(ItemsAbstractFactory):
    """ Enemy items concrete factory """
    def create_body(self):
        return [[1, 1], [1, 4], [2, 11], [2, 15], [1, 18], [0, 19], [-1, 18], [-2, 15], [-2, 11], [-1, 4], [-1, 1]]

    def create_left_wing(self):
        return [[-2, 11], [-9, 7], [-10, 5], [-9, 9], [-2, 15]]

    def create_right_wing(self):
        return [[2, 11], [9, 7], [10, 5], [9, 9], [2, 15]]

    def create_right_rear_wing(self):
        return [[1, 1], [3, 0], [4, 1], [1, 4]]

    def create_left_rear_wing(self):
        return [[-1, 1], [-3, 0], [-4, 1], [-1, 4]]

    def create_weapon(self):
        return [[0, 0]]


class Enemy2ItemsFactory(ItemsAbstractFactory):
    """ Enemy items concrete factory """
    def create_body(self):
        return [[1, 1], [1, 4], [2, 11], [2, 15], [1, 18], [0, 19], [-1, 18], [-2, 15], [-2, 11], [-1, 4], [-1, 1]]

    def create_left_wing(self):
        return [[-2, 11], [-6, 10], [-10, 10], [-8, 14], [-2, 15]]

    def create_right_wing(self):
        return [[2, 11], [6, 10], [10, 10], [8, 14], [2, 15]]

    def create_right_rear_wing(self):
        return [[1, 1], [5, 0], [4, 3], [1, 4]]

    def create_left_rear_wing(self):
        return [[-1, 1], [-5, 0], [-4, 3], [-1, 4]]

    def create_weapon(self):
        return [[0, 0]]


class Enemy3ItemsFactory(ItemsAbstractFactory):
    """ Enemy items concrete factory """
    def create_body(self):
        return [[1, 1], [1, 4], [2, 8], [2, 15], [1, 18], [0, 19], [-1, 18], [-2, 15], [-2, 8], [-1, 4], [-1, 1]]

    def create_left_wing(self):
        return [[-11, 5], [-10, 10], [-8, 14], [-2, 15], [-2, 11], [-2, 8], [-5, 7], [-5, 8], [-8, 7], [-8, 6]]

    def create_right_wing(self):
        return [[11, 5], [10, 10], [8, 14], [2, 15], [2, 11], [2, 8], [5, 7], [5, 8], [8, 7], [8, 6]]

    def create_right_rear_wing(self):
        return [[1, 1], [3, 0], [2, 3], [1, 4]]

    def create_left_rear_wing(self):
        return [[-1, 1], [-3, 0], [-2, 3], [-1, 4]]

    def create_weapon(self):
        return [[0, 0]]


class RocketItemsFactory(ItemsAbstractFactory):
    """ Weapon items concrete factory """

    def create_body(self):
        return [[0, 0], [1, 1], [1, 3], [-1, 3], [-1, 1]]

    def create_left_wing(self):
        pass

    def create_right_wing(self):
        pass

    def create_right_rear_wing(self):
        pass

    def create_left_rear_wing(self):
        pass

    def create_weapon(self):
        pass


class AircraftFactory(EnemyAbstractFactory):
    """ Concrete aircraft factory """
    def create_enemy(self):
        ship = Ship()
        ship.set_part('body', self.items_factory.create_body())
        ship.set_part('leftwing', self.items_factory.create_left_wing())
        ship.set_part('rightwing', self.items_factory.create_right_wing())
        ship.set_part('leftrearwing', self.items_factory.create_left_rear_wing())
        ship.set_part('rightrearwing', self.items_factory.create_right_rear_wing())
        ship.set_part('weapon', self.items_factory.create_weapon())
        return ship


class RocketFactory(EnemyAbstractFactory):
    """ Concrete weapon factory """
    def create_enemy(self):
        ship = Ship()
        ship.set_part('body', self.items_factory.create_body())
        return ship
