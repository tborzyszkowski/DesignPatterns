# Copyright (C) 2019 Wojciech Dunia
# w.dunia@gmail.com

from abc import ABC
from objects import PrimaryShip, Ship
from observer import Observer
from random import random


class ShipDecorator(PrimaryShip, Observer, ABC):
    def __init__(self, ship: Ship):
        self.ship = ship


class DestroyShip(ShipDecorator):
    def do(self, state):
        self.ship.do(state)

    def get_pos_x(self):
        return self.ship.get_pos_x()

    def get_pos_y(self):
        return self.ship.get_pos_y()

    def go_left(self):
        self.ship.go_left()

    def go_right(self):
        self.ship.go_right()

    def go_up(self):
        self.ship.go_up()

    def go_down(self):
        self.ship.go_down()

    def set_part(self, name: str, elements_list: list):
        self.ship.set_part(name, elements_list)

    def get_part(self, name: str):
        parts = self.ship.get_part(name)
        return [[i[0]+random()*6-3, i[1]+random()*6-3] for i in parts]

    def set_part_color(self, name: str, color: tuple):
        self.ship.set_part_color(name, color)

    def get_part_color(self, name: str):
        return self.ship.get_part_color(name)

    def get_scale(self):
        self.ship.get_scale()

    def set_scale(self, scale):
        self.ship.set_scale(scale)

    def get_speed(self):
        self.ship.get_speed()

    def set_speed(self, speed):
        self.ship.set_speed(speed)


class SlowDownShip(ShipDecorator):
    def __init__(self, ship: Ship):
        super().__init__(ship)
        actual_speed = self.ship.get_speed()
        self.ship.set_speed(actual_speed / 2)

    def do(self, state):
        self.ship.do(state)

    def get_pos_x(self):
        return self.ship.get_pos_x()

    def get_pos_y(self):
        return self.ship.get_pos_y()

    def go_left(self):
        self.ship.go_left()

    def go_right(self):
        self.ship.go_right()

    def go_up(self):
        self.ship.go_up()

    def go_down(self):
        self.ship.go_down()

    def set_part(self, name: str, elements_list: list):
        self.ship.set_part(name, elements_list)

    def get_part(self, name: str):
        return self.ship.get_part(name)

    def set_part_color(self, name: str, color: tuple):
        self.ship.set_part_color(name, color)

    def get_part_color(self, name: str):
        return self.ship.get_part_color(name)

    def get_scale(self):
        self.ship.get_scale()

    def set_scale(self, scale):
        self.ship.set_scale(scale)

    def get_speed(self):
        self.ship.get_speed()

    def set_speed(self, speed):
        self.ship.set_speed(speed)


class InflateShip(ShipDecorator):
    def do(self, state):
        self.ship.do(state)

    def get_pos_x(self):
        return self.ship.get_pos_x()

    def get_pos_y(self):
        return self.ship.get_pos_y()

    def go_left(self):
        self.ship.go_left()

    def go_right(self):
        self.ship.go_right()

    def go_up(self):
        self.ship.go_up()

    def go_down(self):
        self.ship.go_down()

    def set_part(self, name: str, elements_list: list):
        self.ship.set_part(name, elements_list)

    def get_part(self, name: str):
        self.ship.set_scale(self.ship.get_scale() + 0.01)
        self.ship.set_speed(self.ship.get_speed() + 0.01)
        return self.ship.get_part(name)

    def set_part_color(self, name: str, color: tuple):
        self.ship.set_part_color(name, color)

    def get_part_color(self, name: str):
        return self.ship.get_part_color(name)

    def get_scale(self):
        self.ship.get_scale()

    def set_scale(self, scale):
        self.ship.set_scale(scale)

    def get_speed(self):
        self.ship.get_speed()

    def set_speed(self, speed):
        self.ship.set_speed(speed)


class ShipFalling(ShipDecorator):
    def do(self, state):
        if state == 'up':
            self.go_up()
        elif state == 'down':
            self.go_down()
        elif state == 'left':
            self.go_left()
        elif state == 'right':
            self.go_right()
        self.ship.do(state)

    def get_pos_x(self):
        return self.ship.get_pos_x()

    def get_pos_y(self):
        return self.ship.get_pos_y()

    def go_left(self):
        self.ship.go_left()

    def go_right(self):
        self.ship.go_right()

    def go_up(self):
        self.ship.go_up()

    def go_down(self):
        scale = self.ship.get_scale()
        speed = self.ship.get_speed()
        if scale > 1:
            self.ship.set_scale(scale - 0.1)
            self.ship.set_speed(speed + 0.4)
        else:
            self.ship.set_position(-100, 0)
        self.ship.go_down()

    def set_part(self, name: str, elements_list: list):
        self.ship.set_part(name, elements_list)

    def get_part(self, name: str):
        return self.ship.get_part(name)

    def set_part_color(self, name: str, color: tuple):
        self.ship.set_part_color(name, color)

    def get_part_color(self, name: str):
        return self.ship.get_part_color(name)

    def get_scale(self):
        self.ship.get_scale()

    def set_scale(self, scale):
        self.ship.set_scale(scale)

    def get_speed(self):
        self.ship.get_speed()

    def set_speed(self, speed):
        self.ship.set_speed(speed)
