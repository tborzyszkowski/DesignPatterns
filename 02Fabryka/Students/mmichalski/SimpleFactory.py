from __future__ import generators
import random

class Kompania(object):
    @staticmethod
    def formuj(type):
        if type == "Szeregowy": return Szeregowy()
        elif type == "Porucznik": return Porucznik()
        elif type == "Kapral": return Kapral()
        else: 'Nie istnieje taki wojskowy: ' + type

class Szeregowy(Kompania):
    def melduj(self): print('Szeregowy melduje!')

class Kapral(Kompania):
    def melduj(self): print("Kapral melduje!")

class Porucznik(Kompania):
    def melduj(self): print("Porucznik melduje!")

# generuj nazwy
def generuj(n):
    types = Kompania.__subclasses__()
    for i in range(n):
        yield random.choice(types).__name__

kompania = [Kompania.formuj(i) for i in generuj(7)]

for osoba in kompania:
    osoba.melduj()