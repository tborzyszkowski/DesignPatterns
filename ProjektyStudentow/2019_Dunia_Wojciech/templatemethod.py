# Copyright (C) 2019 Wojciech Dunia
# w.dunia@gmail.com

import pygame, sys
from objects import Counters
from observer import EnemiesMovementObservable
from abstractfactory import *
from random import randint, random, choice
from decorator import InflateShip, SlowDownShip, DestroyShip, ShipFalling
from facade import ProtagonistFacade


class AbstractGame(ABC):
    __instance = {}
    __lock = threading.Lock()

    def __new__(cls):
        if type(object.__new__(cls)).__name__ not in cls.__instance:
            with cls.__lock:
                if type(object.__new__(cls)).__name__ not in cls.__instance:
                    cls.__instance[type(object.__new__(cls)).__name__] = object.__new__(cls)
        return cls.__instance[type(object.__new__(cls)).__name__]

    def __init__(self):
        self.counter = None
        self.full_screen = False
        self.screen = None
        self.width = 0
        self.height = 0
        self.new_time = 0
        self.old_time = 0
        self.clock = pygame.time.Clock()
        self.player = None
        self.enemy_items = None
        self.rocket_items = None
        self.rocket_factory = None
        self.enemies_observable = None
        self.rockets_observable = None
        self.game_over = False

    def run(self):
        self.init_game()
        self.init_graphics()
        self.init_factories()
        self.init_builders()
        self.init_observables()
        self.create_player()
        while True:
            self.clock.tick(60)
            self.control_keys()
            self.create_enemies()
            self.change_observables()
            self.draw_enemies()
            self.draw_rockets()
            self.draw_player()
            self.draw_counters()
            self.check_collisions()
            self.refresh_screen()
            self.stop()

    def _get_tick(self):
        return pygame.time.get_ticks()

    @abstractmethod
    def init_game(self): pass

    @abstractmethod
    def init_graphics(self): pass

    @abstractmethod
    def init_factories(self): pass

    @abstractmethod
    def init_builders(self): pass

    @abstractmethod
    def init_observables(self): pass

    @abstractmethod
    def control_keys(self): pass

    @abstractmethod
    def create_enemies(self): pass

    @abstractmethod
    def create_player(self): pass

    @abstractmethod
    def change_observables(self): pass

    @abstractmethod
    def draw_enemies(self): pass

    @abstractmethod
    def draw_rockets(self): pass

    @abstractmethod
    def draw_player(self): pass

    @abstractmethod
    def draw_counters(self): pass

    @abstractmethod
    def check_collisions(self): pass

    @abstractmethod
    def refresh_screen(self): pass

    @abstractmethod
    def stop(self): pass


class ArcadeGame(AbstractGame):
    def init_game(self):
        self.counter = Counters()
        pygame.font.init()

    def init_graphics(self):
        if self.full_screen:
            self.screen = pygame.display.set_mode((0, 0), pygame.FULLSCREEN)
        else:
            self.screen = pygame.display.set_mode((1366, 768))
        self.width, self.height = pygame.display.Info().current_w, pygame.display.Info().current_h
        self.clock = pygame.time.Clock()

    def init_factories(self):
        # Enemy factories
        self.enemy_items = Enemy1ItemsFactory(), Enemy2ItemsFactory(), Enemy3ItemsFactory()

        # Rocket factory
        self.rocket_items = RocketItemsFactory()
        self.rocket_factory = RocketFactory(self.rocket_items)

    def init_builders(self):
        # Player fluent builder
        self.player = ProtagonistFacade(self.width // 2, self.height * 0.8).create_ship()
        self.player = ProtagonistFacade(self.width // 2, self.height * 0.8, self.player).show_everything()

    def init_observables(self):
        # Observable
        self.enemies_observable = EnemiesMovementObservable()
        self.rockets_observable = EnemiesMovementObservable()

    def control_keys(self):
        self.new_time = self._get_tick()
        keys = pygame.key.get_pressed()
        if keys[pygame.K_LEFT]:
            self.player.go_left()
        if keys[pygame.K_RIGHT]:
            self.player.go_right()
        if keys[pygame.K_UP]:
            self.player.go_up()
        if keys[pygame.K_DOWN]:
            self.player.go_down()
        if keys[pygame.K_a]:
            self.player = ProtagonistFacade(self.width, self.height, self.player).increase_speed()
        if keys[pygame.K_z]:
            self.player = ProtagonistFacade(self.width, self.height, self.player).decrease_speed()
        if keys[pygame.K_1]:
            self.player = ProtagonistFacade(self.width, self.height, self.player).show_weapon()
        if keys[pygame.K_q]:
            self.player = ProtagonistFacade(self.width, self.height, self.player).hide_weapon()
        if keys[pygame.K_2]:
            self.player = ProtagonistFacade(self.width, self.height, self.player).show_engines()
        if keys[pygame.K_w]:
            self.player = ProtagonistFacade(self.width, self.height, self.player).hide_engines()
        if keys[pygame.K_SPACE]:
            self.new_time = self._get_tick()
            if self.new_time > self.old_time + 250:
                rocket = self.rocket_factory.create_enemy()
                rocket.set_speed(6)
                rocket.set_position(*self.player.get_position())
                self.rockets_observable.subscribe(rocket)
                self.old_time = self.new_time
        if keys[pygame.K_f]:
            self.full_screen ^= True
            if self.full_screen:
                self.screen = pygame.display.set_mode((self.width, self.height), pygame.FULLSCREEN)
            else:
                self.screen = pygame.display.set_mode((self.width, self.height))
        if keys[pygame.K_ESCAPE]:
            sys.exit(0)

    def create_enemies(self):
        # Create enemies in abstract factory
        if not self.game_over and len(self.enemies_observable.subscribed) < 80 and random() > 0.8:
            for i in range(1):
                enemy_factory = AircraftFactory(choice(self.enemy_items))
                enemy = enemy_factory.create_enemy()
                enemy.set_speed(random() + 1)
                enemy.set_scale(random()*3 + 2)
                enemy.set_position(randint(1, self.width), -100)
                # Subscribe enemy movement
                self.enemies_observable.subscribe(enemy)

    def create_player(self):
        pass

    def change_observables(self):
        # Observable - detecting movement
        # self.enemies_observable.value = choice(['right', 'left'])
        self.enemies_observable.value = 'down'
        self.rockets_observable.value = 'up'

    def draw_enemies(self):
        # Draw enemies
        for e in self.enemies_observable.subscribed:
            if int(e.get_pos_y()) > self.height:
                self.enemies_observable.unsubscribe(e)
            pygame.draw.polygon(self.screen, (205, 149, 12), e.get_part('body'))
            pygame.draw.polygon(self.screen, (238, 173, 14), e.get_part('leftwing'))
            pygame.draw.polygon(self.screen, (238, 173, 14), e.get_part('rightwing'))
            pygame.draw.polygon(self.screen, (238, 173, 14), e.get_part('leftrearwing'))
            pygame.draw.polygon(self.screen, (238, 173, 14), e.get_part('rightrearwing'))

    def draw_rockets(self):
        # Draw rockets
        for r in self.rockets_observable.subscribed:
            if r.get_pos_y() < 1:
                self.rockets_observable.unsubscribe(r)
            pygame.draw.polygon(self.screen, (205, 149, 12), r.get_part('body'))

    def draw_player(self):
        # Draw player
        for part_name in self.player.parts:
            pygame.draw.polygon(self.screen, self.player.get_part_color(part_name), self.player.get_part(part_name))

    def draw_counters(self):
        self.counter.draw(10, 10, self.screen)

    def check_collisions(self):
        for e in self.enemies_observable.subscribed:
            # Primitive player collision check
            player_x, player_y = self.player.get_pos_x(), self.player.get_pos_y()
            if player_x + 20 < e.get_pos_x() + 20 and player_x + 20 > e.get_pos_x() - 20 and \
                player_y < e.get_pos_y()+ 20 and player_y > e.get_pos_y() - 20:
                self.enemies_observable.unsubscribe(e)
                self.counter.sub_live(self)
            for r in self.rockets_observable.subscribed:
                # Primitive enemies collision check
                if r.get_pos_x() + 5 < e.get_pos_x() + 20 and r.get_pos_x() - 5 > e.get_pos_x() - 20 \
                    and r.get_pos_y() + 5 < e.get_pos_y() + 20 and r.get_pos_y() - 5 > e.get_pos_y() - 20:
                    self.enemies_observable.unsubscribe(e)
                    self.counter.add_points(10)
                    if isinstance(e, Ship):
                        # Chose one decorator
                        decorator = choice([ShipFalling(e), DestroyShip(e), InflateShip(e), SlowDownShip(e)])
                        self.enemies_observable.subscribe(decorator)
                    else:
                        self.counter.add_enemies()
                        self.counter.add_points(10)
                    self.rockets_observable.unsubscribe(r)

    def refresh_screen(self):
        pygame.display.flip()
        self.screen.fill((28, 134, 238))

    def stop(self):
        if self.game_over:
            self.counter.game_over(self.width, self.height ,self.screen)
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                sys.exit(0)
