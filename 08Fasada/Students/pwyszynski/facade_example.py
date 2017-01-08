#!/usr/bin/env python3
# -*- coding: utf-8 -*-

__author__ = "Przemysław Wyszyński"


class Procesor:
    def zawies(self):
        print("Procesor: Zawieś")

    def skocz(self, position):
        print("Procesor: Skocz do {}".format(position))

    def wykonaj(self):
        print("Procesor: Wykonuj")


class RAM:
    def laduj(self, position, data): print("Pamięć: Ładuj z pozycji {} - dane: {}".format(position, data))


class Dysk:
    def czytaj(self, lba, size): print("Dysk: Czytaj - lba: {}, rozmiar: {}".format(lba, size))


# Facade
class Komputer:
    def __init__(self):
        self.procesor = Procesor()
        self.pamiec = RAM()
        self.dysk = Dysk()

    def start_komputera(self):
        self.procesor.zawies()
        self.pamiec.laduj(0, self.dysk.czytaj(0, 1024))
        self.procesor.skocz(10)
        self.procesor.wykonaj()


# Client
if __name__ == '__main__':
    fasada = Komputer()
    fasada.start_komputera()
