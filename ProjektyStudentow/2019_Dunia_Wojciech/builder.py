# Copyright (C) 2019 Wojciech Dunia
# w.dunia@gmail.com

from abc import ABC, abstractmethod
from objects import Ship


class ProtagonistBuilder(ABC):

    def __init__(self, ship=None):
        if ship is None:
            self.ship = Ship()
        else:
            # Rebuild object if ship is set
            self.ship = ship

    def build(self):
        return self.ship

    @abstractmethod
    def set_body(self, is_set=True): pass

    @abstractmethod
    def set_left_wing(self, is_set=True): pass

    @abstractmethod
    def set_right_wing(self, is_set=True): pass

    @abstractmethod
    def set_center_gun(self, is_set=True): pass

    @abstractmethod
    def set_left_gun(self, is_set=True): pass

    @abstractmethod
    def set_right_gun(self, is_set=True): pass

    @abstractmethod
    def set_center_engine(self, is_set=True): pass

    @abstractmethod
    def set_left_engine(self, is_set=True): pass

    @abstractmethod
    def set_right_engine(self, is_set=True): pass

    @abstractmethod
    def set_speed(self, speed): pass

    @abstractmethod
    def set_position(self, screen_x: int, screen_y: int): pass


class ConcreteProtagonist(ProtagonistBuilder):
    def set_body(self, is_set=True):
        self.ship.set_part('body', [[0, 1], [2, 2], [3, 5], [3, 9], [1, 10], [-1, 10], [-3, 9], [-3, 5], [-2, 2]], is_set)
        self.ship.set_part_color('body', (158, 37, 178))
        return self

    def set_left_wing(self, is_set=True):
        self.ship.set_part('leftwing', [[-3, 5], [-6, 6], [-7, 10], [-4, 10], [-3, 9]], is_set)
        self.ship.set_part_color('leftwing', (239, 144, 255))
        return self

    def set_right_wing(self, is_set=True):
        self.ship.set_part('rightwing', [[3, 5], [6, 6], [7, 10], [4, 10], [3, 9]], is_set)
        self.ship.set_part_color('rightwing', (239, 144, 255))
        return self

    def set_center_gun(self, is_set=True):
        self.ship.set_part('centergun', [[1, 0], [1, 3], [-1, 3], [-1, 0]], is_set)
        self.ship.set_part_color('centergun', (144, 178, 103))
        return self

    def set_left_gun(self, is_set=True):
        self.ship.set_part('leftgun', [[-5, 4], [-5, 8], [-4, 8], [-4, 4]], is_set)
        self.ship.set_part_color('leftgun', (175, 255, 83))
        return self

    def set_right_gun(self, is_set=True):
        self.ship.set_part('rightgun', [[5, 4], [5, 8], [4, 8], [4, 4]], is_set)
        self.ship.set_part_color('rightgun', (175, 255, 83))
        return self

    def set_center_engine(self, is_set=True):
        self.ship.set_part('centerengine', [[1, 10], [2, 13], [2, 14], [-2, 14], [-2, 13], [-1, 10]], is_set)
        self.ship.set_part_color('centerengine', (232, 98, 255))
        return self

    def set_left_engine(self, is_set=True):
        self.ship.set_part('leftengine', [[-6, 10], [-7, 11], [-7, 12], [-4, 12], [-4, 11], [-5, 10]], is_set)
        self.ship.set_part_color('leftengine', (232, 98, 255))
        return self

    def set_right_engine(self, is_set=True):
        self.ship.set_part('rightengine', [[6, 10], [7, 11], [7, 12], [4, 12], [4, 11], [5, 10]], is_set)
        self.ship.set_part_color('rightengine', (232, 98, 255))
        return self

    def set_speed(self, speed):
        self.ship.set_speed(speed)
        return self

    def set_position(self, screen_x: int, screen_y: int):
        self.ship.set_position(screen_x, screen_y)
        return self
