from abc import ABC, abstractmethod
import copy


class MonsterPrototype(ABC):
    @abstractmethod
    def show(self):
        pass

    @abstractmethod
    def set_hp(self, hp: int):
        pass

    @abstractmethod
    def copy(self):
        pass


class Monster(MonsterPrototype):
    """ attack: int, defense: int, hp: int, armor: list, weapon: list """
    def __init__(self, attack: int, defense: int, hp: int, armor: list, weapon: list):
        self._attack = attack
        self._defense = defense
        self._health_points = hp
        self._armor = armor
        self._weapon = weapon

    def set_hp(self, hp: int):
        self._health_points = hp

    def show(self):
        print('{:>12} {}'.format('Monster id:', id(self)))
        print('{:>12} {}'.format('Attack:', self._attack))
        print('{:>12} {}'.format('Defence:', self._defense))
        print('{:>12} {}'.format('Health:', self._health_points))
        print('{:>12} {}'.format('Armor:', self._armor))
        print('{:>12} {}'.format('Weapon:', self._weapon))
        print('\n')

    def copy(self):
        return copy.copy(self)
