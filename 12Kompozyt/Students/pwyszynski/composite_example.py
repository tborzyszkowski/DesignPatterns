#!/usr/bin/env python3
# -*- coding: utf-8 -*-

__author__ = "Przemysław Wyszyński"

class Komponent(object):
    def __init__(self, *args, **kw):
        pass

    def funkcja_komponentu(self):
        pass


class Lisc(Komponent):
    def __init__(self, *args, **kw):
        Komponent.__init__(self, *args, **kw)

    def funkcja_komponentu(self):
        print("Jestem w funkcji komponentu!")

class SuchyLisc(Komponent):
    def __init__(self, *args, **kwargs):
        Komponent.__init__(self, *args, **kwargs)

    def funkcja_komponentu(self):
        print("Inny komponent, inna wiadomosc.")

class Kompozyt(Komponent):
    def __init__(self, *args, **kw):
        Komponent.__init__(self, *args, **kw)
        self.liscie = []

    def dodaj_lisc(self, lisc):
        self.liscie.append(lisc)

    def usun_lisc(self, lisc):
        self.liscie.remove(lisc)

    def funkcja_komponentu(self):
        for i in self.liscie:
            i.funkcja_komponentu()

if __name__ == "__main__":
    c = Kompozyt()
    l = Lisc()
    l_two = Lisc()
    l_three = SuchyLisc()
    c.dodaj_lisc(l)
    c.dodaj_lisc(l_two)
    c.dodaj_lisc(l_three)
    c.funkcja_komponentu()
