# Copyright (C) 2019 Wojciech Dunia
# w.dunia@gmail.com

from builder import ProtagonistBuilder, ConcreteProtagonist
import threading


class ProtagonistFacade:
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls, *args, **kwargs):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def __init__(self, width, height, ship: ProtagonistBuilder = None):
        self.ship = ship
        self.width = width
        self.height = height

    def create_ship(self):
        return ConcreteProtagonist() \
            .set_left_gun() \
            .set_right_gun() \
            .set_center_gun() \
            .set_body()\
            .set_left_wing()\
            .set_right_wing()\
            .set_speed(3)\
            .set_position(self.width // 2, self.height * 0.8)\
            .build()

    def show_ship(self):
        if self.ship is not None:
            return ConcreteProtagonist(self.ship) \
                .set_body() \
                .set_left_wing() \
                .set_right_wing() \
                .build()
        else:
            self.create_ship()

    def show_everything(self):
        return ConcreteProtagonist(self.ship) \
            .set_left_gun() \
            .set_right_gun() \
            .set_center_gun() \
            .set_body() \
            .set_left_wing() \
            .set_right_wing() \
            .set_left_engine() \
            .set_right_engine() \
            .set_center_engine() \
            .build()

    def hide_engines(self):
        return ConcreteProtagonist(self.ship) \
            .set_left_engine(False) \
            .set_right_engine(False) \
            .set_center_engine(False) \
            .build()

    def show_engines(self):
        return ConcreteProtagonist(self.ship) \
            .set_left_engine() \
            .set_right_engine() \
            .set_center_engine() \
            .build()

    def show_weapon(self):
        return ConcreteProtagonist(self.ship) \
            .set_left_gun() \
            .set_right_gun() \
            .set_center_gun() \
            .build()

    def hide_weapon(self):
        return ConcreteProtagonist(self.ship) \
            .set_left_gun(False) \
            .set_right_gun(False) \
            .set_center_gun(False) \
            .build()

    def increase_speed(self):
        if self.ship is not None:
            speed = self.ship.speed
            if speed < 10:
                speed += 0.5
            return ConcreteProtagonist(self.ship) \
                .set_speed(speed) \
                .build()
        else:
            self.create_ship()

    def decrease_speed(self):
        if self.ship is not None:
            speed = self.ship.speed
            if speed >= 1:
                speed -= 0.5
            return ConcreteProtagonist(self.ship) \
                .set_speed(speed) \
                .build()
        else:
            self.create_ship()

    def enlarge_size(self):
        pass

    def reduce_size(self):
        pass
