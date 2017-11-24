#!/usr/bin/env python3
# -*- coding: utf-8 -*-
from collections import namedtuple
from enum import Enum

__author__ = "Przemysław Wyszyński"

# Enum dla rozmiaru pizzy
class Rozmiar(Enum):
    DUZA = 0
    SREDNIA = 1
    MALA = 2

# Enum dla typu ciasta
class Ciasto(Enum):
    GRUBE = 0
    SREDNIE = 1
    CIENKIE = 2


# Obiekt PizzaBuilder'a, pozwalający na konfigurację pizzy (ciasto, rozmiar, składniki)
class PizzaBuilder(object):
    def __init__(self):
        self.pizza = { 'rozmiar': "", 'ciasto': "", 'skladniki': []}

    def rozmiar(self, rozmiar: Rozmiar):
        self.pizza['rozmiar'] = rozmiar
        return self

    def ciasto(self, ciasto: Ciasto):
        self.pizza['ciasto'] = ciasto
        return self

    def skladniki(self, skladnik):
        self.pizza['skladniki'].append(skladnik)
        return self

    def build(self):
        return Pizza(self)


#Tworzenie obiektu pizzy przy pomocy obiektu builder'a.
class Pizza(object):
    def __init__(self, builder: PizzaBuilder):
        self.rozmiar = builder.pizza['rozmiar']
        self.ciasto = builder.pizza['ciasto']
        self.skladniki = builder.pizza['skladniki']

    def opis(self):
        print("Pizza w rozmiarze {}, na ciescie {}".format(self.rozmiar.name, self.ciasto.name))
        print("Składniki:")
        [print("- {}".format(x)) for x in self.skladniki]

if __name__ == '__main__':
    builder = PizzaBuilder()
    pizza = builder.rozmiar(Rozmiar.DUZA)\
                   .ciasto(Ciasto.SREDNIE)\
                   .skladniki("Ser")\
                   .skladniki("Pomidor")\
                   .skladniki("Boczek")\
                   .build()

    pizza.opis()
