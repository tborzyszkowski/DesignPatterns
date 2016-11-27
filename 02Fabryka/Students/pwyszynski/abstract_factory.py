#!/usr/bin/env python3
# -*- coding: utf-8 -*-

__author__ = "Przemysław Wyszyński"

from abc import ABCMeta

# Fabryka abstrakcyjna, zwracająca fabrykę krzeseł lub stolików w zależności od parametru.
class Factory(object):

    @staticmethod
    def get_factory(factory):
        if factory == 'stolik':
            return TableFactory()
        elif factory == 'krzeslo':
            return ChairFactory()
        raise TypeError('Nieznany mebel.')

# Obiekty konkretnych fabryk tworzone przez fabrykę abstrakcyjną.
class TableFactory(object):
    def get_furniture(self):
        return Table()


class ChairFactory(object):
    def get_furniture(self):
        return Chair()

# Klasa abstrakcyjna (substytut interfejsów w Pythonie [wielodziedziczenie]).
class Furniture(object):
    __metaclass__ = ABCMeta
    def stand(self):
        pass

# Przykładowe obiekty tworzone przez fabryki.
class Chair(Furniture):
    def stand(self):
        print("Chair is standing...")


class Table(Furniture):
    def stand(self):
        print("Table is standing...")

# Przykładowe wywołanie.
if __name__ == "__main__":
    factory = Factory.get_factory("stolik")
    furniture = factory.get_furniture()
    furniture.stand()

    factory = Factory.get_factory("krzeslo")
    furniture = factory.get_furniture()
    furniture.stand()