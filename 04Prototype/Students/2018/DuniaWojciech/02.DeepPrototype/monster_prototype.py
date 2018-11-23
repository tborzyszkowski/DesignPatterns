from abc import ABC, abstractmethod
import copy
import pickle

class DzidaPrototype(ABC):
    @abstractmethod
    def deep_copy(self):
        pass


class Dzida(DzidaPrototype):
    def __init__(self, nazwa: str):
        self.przeddzidzie = None
        self.sroddzidzie = None
        self.zadzidzie = None
        self.nazwa = nazwa

    def deep_copy(self):
        return copy.deepcopy(self)

    def wypisz_dzide(self):
        pass

    def set_dzida(self, przeddzidzie, sroddzidzie, zadzidzie):
        self.przeddzidzie = przeddzidzie
        self.sroddzidzie = sroddzidzie
        self.zadzidzie = zadzidzie


class MonsterPrototype(ABC):
    @abstractmethod
    def show(self):
        pass

    @abstractmethod
    def set_hp(self, hp: int):
        pass

    @abstractmethod
    def deep_copy_pickle(self):
        pass


class Monster(MonsterPrototype):
    """ attack: int, defense: int, hp: int, armor: list, weapon: list """
    def __init__(self, hp: int, dzida: Dzida):
        self._health_points = hp
        self._weapon = dzida

    def set_hp(self, hp: int):
        self._health_points = hp

    def set_weapon(self, weapon):
        self._weapon = weapon

    @staticmethod
    def show_dzida(dzida: Dzida, wynik = []):
        if dzida is not None:
            print(dzida.nazwa)
            print(dzida.przeddzidzie.nazwa)
            print(dzida.przeddzidzie.przeddzidzie.nazwa)
            print(dzida.sroddzidzie.sroddzidzie.nazwa)
            print(dzida.zadzidzie.zadzidzie.nazwa)
            print(dzida.sroddzidzie.nazwa)
            print(dzida.przeddzidzie.przeddzidzie.nazwa)
            print(dzida.sroddzidzie.sroddzidzie.nazwa)
            print(dzida.zadzidzie.zadzidzie.nazwa)
            print(dzida.zadzidzie.nazwa)
            print(dzida.przeddzidzie.przeddzidzie.nazwa)
            print(dzida.sroddzidzie.sroddzidzie.nazwa)
            print(dzida.zadzidzie.zadzidzie.nazwa)
        else:
            print('Brak dzidy')

    def show(self):
        print('{:>12} {}'.format('Monster id:', id(self)))
        print('{:>12} {}'.format('Health:', self._health_points))
        Monster.show_dzida(self._weapon)
        print('\n')

    def deep_copy(self):
        return copy.deepcopy(self)

    def deep_copy_pickle(self):
        dump = pickle.dumps(self)
        return pickle.loads(dump)

