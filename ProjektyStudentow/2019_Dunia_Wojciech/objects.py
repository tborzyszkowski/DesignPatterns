# Copyright (C) 2019 Wojciech Dunia
# w.dunia@gmail.com

from abc import ABC, abstractmethod
from observer import Observer
import pygame


class PrimaryShip(ABC):
    @abstractmethod
    def go_left(self): pass

    @abstractmethod
    def go_right(self): pass

    @abstractmethod
    def go_up(self): pass

    @abstractmethod
    def go_down(self): pass

    @abstractmethod
    def set_part(self, name: str, elements_list: list): pass

    @abstractmethod
    def set_part_color(self, name: str, color: tuple): pass

    @abstractmethod
    def get_part(self, name: str): pass

    @abstractmethod
    def get_part_color(self, name: str): pass

    @abstractmethod
    def get_pos_x(self): pass

    @abstractmethod
    def get_pos_y(self): pass

    @abstractmethod
    def get_scale(self): pass

    @abstractmethod
    def set_scale(self, scale): pass

    @abstractmethod
    def get_speed(self): pass

    @abstractmethod
    def set_speed(self, speed): pass


class Ship(PrimaryShip, Observer):
    # Observer method
    def do(self, state):
        if state == 'up':
            self.go_up()
        elif state == 'down':
            self.go_down()
        elif state == 'left':
            self.go_left()
        elif state == 'right':
            self.go_right()

    def __init__(self, screen_x=0, screen_y=0, speed=1, scale = 5):
        super().__init__()
        self.pos_y = screen_y
        self.pos_x = screen_x
        self.speed = speed
        self.parts = {}
        self.parts_color = {}
        self.scale = scale

    def get_pos_x(self):
        return self.pos_x

    def get_pos_y(self):
        return self.pos_y

    def set_position(self, screen_x: int, screen_y: int):
        self.pos_y = screen_y
        self.pos_x = screen_x

    def get_position(self):
        return [self.pos_x, self.pos_y]

    def set_speed(self, speed: int):
        self.speed = speed

    def go_left(self):
        self.pos_x -= self.get_speed()

    def go_right(self):
        self.pos_x += self.get_speed()

    def go_up(self):
        self.pos_y -= self.get_speed()

    def go_down(self):
        self.pos_y += self.get_speed()

    def set_part(self, name: str, elements_list: list, is_set=True):
        if is_set:
            self.parts.update({name: elements_list})
        elif name in self.parts:
            self.parts.pop(name)

    def set_part_color(self, name: str, color: tuple):
        self.parts_color.update({name: color})

    def get_part(self, name: str):
        item = []
        for i in self.parts[name]:
            item.append([i[0] * self.get_scale() + self.pos_x, i[1] * self.get_scale() + self.pos_y])
        return item

    def get_part_color(self, name: str):
        if name in self.parts_color:
            return self.parts_color[name]
        else:
            return (200, 200, 200)

    def get_scale(self):
        return self.scale

    def set_scale(self, scale):
        self.scale = scale

    def get_speed(self):
        return self.speed

    def set_speed(self, speed):
        self.speed = speed


class Counters:
    def __init__(self):
        self.points = 0
        self.enemies = 0
        self.lives = 3

    def add_points(self, value):
        self.points += value

    def add_enemies(self):
        self.enemies += 1

    def sub_live(self, over):
        if self.lives > 1 and not over.game_over:
            self.lives -= 1
        else:
            over.game_over = True
            self.lives = 0

    def get_lives(self):
        return self.lives

    def draw(self, pos_x, pos_y, screen):
        myfont = pygame.font.SysFont("monospace", 25)
        label = myfont.render("Cash: {} Annihilated: {} Pilots: {}".format(self.points, self.enemies, self.lives), 1, (255, 255, 255))
        screen.blit(label, (pos_x, pos_y))

    def game_over(self, screen_x, screen_y, screen):
        myfont = pygame.font.SysFont("monospace", 50)
        label = myfont.render("GAME OVER", 1, (255, 255, 255))
        screen.blit(label, (screen_x // 2 - 150, screen_y // 2))
