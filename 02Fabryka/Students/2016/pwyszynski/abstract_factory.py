#!/usr/bin/env python3
# -*- coding: utf-8 -*-

__author__ = "Przemysław Wyszyński"

from abc import ABCMeta

# Fabryka abstrakcyjna, zwracająca fabrykę krzeseł lub stolików w zależności od parametru.
class Factory(object):

    @staticmethod
    def get_factory(factory):
        if factory == 'Ikea':
            return IkeaFactory()
        elif factory == 'BlackRedWhite':
            return BRWFactory()
        raise TypeError('Nieznana firma.')

# Obiekty konkretnych fabryk tworzone przez fabrykę abstrakcyjną.
class IkeaFactory(object):
    def get_chair(self):
        return IkeaChair()

    def get_table(self):
        return IkeaTable()

class BRWFactory(object):
    def get_chair(self):
        return BRWChair()

    def get_table(self):
        return BRWTable()

# Klasa abstrakcyjna (substytut interfejsów w Pythonie [wielodziedziczenie]).
class Furniture(object):
    __metaclass__ = ABCMeta
    def stand(self):
        pass

# Przykładowe obiekty tworzone przez fabryki.
class BRWChair(Furniture):
    def stand(self):
        print("BlackRedWhite chair is standing...")

class IkeaChair(Furniture):
    def stand(self):
        print("Ikea chair is standing...")

class BRWTable(Furniture):
    def stand(self):
        print("BlackRedWhite table is standing...")

class IkeaTable(Furniture):
    def stand(self):
        print("Ikea table is standing...")

# Przykładowe wywołanie.
if __name__ == "__main__":
    krzeslo_ikea = Factory.get_factory("Ikea").get_chair()
    stol_ikea = Factory.get_factory("Ikea").get_table()
    krzeslo_ikea.stand()
    stol_ikea.stand()

    krzeslo_brw = Factory.get_factory("BlackRedWhite").get_chair()
    stol_brw = Factory.get_factory("BlackRedWhite").get_table()
    krzeslo_brw.stand()
    stol_brw.stand()
