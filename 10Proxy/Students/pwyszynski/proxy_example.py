#!/usr/bin/env python3
# -*- coding: utf-8 -*-
from abc import ABCMeta
import sys

__author__ = "Przemysław Wyszyński"


class IKalkulator(metaclass=ABCMeta):
    def dodaj(self, x, y):
        raise NotImplementedError

    def odejmij(self, x, y):
        raise NotImplementedError

    def mnoz(self, x, y):
        raise NotImplementedError

    def dziel(self, x, y):
        raise NotImplementedError

class Kalkulator(IKalkulator):
    def dodaj(self, x, y):
        return x + y

    def odejmij(self, x, y):
        return x - y

    def mnoz(self, x, y):
        return x * y

    def dziel(self, x, y):
        return x / y

class ProxyKalk(IKalkulator):
    def __init__(self):
        self.kalkulator = Kalkulator()

    def dodaj(self, x, y):
        return self.kalkulator.dodaj(x, y)

    def odejmij(self, x, y):
        return self.kalkulator.odejmij(x, y)

    def mnoz(self, x, y):
        return self.kalkulator.mnoz(x, y)

    def dziel(self, x, y):
        if y == 0:
            raise ZeroDivisionError
        return self.kalkulator.dziel(x, y)

if __name__ == "__main__":
    p = ProxyKalk()
    x, y = 9, 3
    funkcje = ['dodaj', 'odejmij', 'mnoz', 'dziel']

    for i in funkcje:
        print(getattr(p, "%s" % i)(x, y))
