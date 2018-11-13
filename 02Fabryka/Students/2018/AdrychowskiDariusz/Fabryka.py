"""0. Klient potrzebuje obiekty należące do kilku (3-4) rodzajów produktów.
	Każdy rodzaj posiada kilka (5-6) konkretnych realizacji.
	Wymyślić i wytworzyć kod opisujący produkty i ich rodzaje.

Dealer samochodowy - Autohause

Wybor samochodu
SUV
Estate -Hatchback
Cross Country
Sedan

Kolor nadwozia
Rozmiar opon
Rodzaj silnika (Benzyna, Diesel, Elektryczny, Hybrid)
Wyposazenie
Finansowanie


"""


from abc import ABC, abstractmethod


class ZamowSamochod():

    def __init__(self):

        self.ciezarowka = CiezaroweAuta()

        samochod = self.ciezarowka.konfigurujAuto('dostawczy')
        print("zamowilem {}".format(samochod.getName()))



class SalonSamochodowy(ABC):
    @abstractmethod
    def konfigurujAuto(self, item):
        pass

    def wybierzElementy(self, typ):
        self.auto = self.konfigurujAuto(typ)
        print("Konfiguruje nowe auto {}. Kolejne kroki: ".format(self.auto.getName()))
        self.auto.kolor()
        self.auto.kola()
        self.auto.silnik()
        self.auto.wyposazenie()
        self.auto.kasa()
        return self.auto


class Auto(ABC):
    def __init__(self):
        self.nazwa = ''
        self.kolor = ''
        self.kola = ''
        self.silnik = ''
        self.wyposazenie = ''
        self.kasa = ''

    def prepare(self):
        print("Zaczynamy wysylanie zamowienia na {}. To moze chwilke potrwac".format(self.nazwa))

    def kolor(self):
        print("Kolor nadwozia i zderzakow")

    def kola(self):
        print("rozmiar kol i rodzaj felg")

    def silnik(self):
        print("Nie wszystkie rodzaje silnikow mozna wybrac do kazdegej z wersji samochodu")

    def wyposazenie(self):
        print("Zakres wyposazenia podstawowego jest predefiniowany")

    def kasa(self):
        print("Jednym z elementow zamowienia jest platnosc")

    def getName(self):
        return self.nazwa

    def __str__(self):
        display = ''
        display += "---- " + self.nazwa
        return display


# Ciezarowki
class CiezaroweAuta(SalonSamochodowy):
    def __init__(self):
        pass

    def konfigurujAuto(self, item):
        if item == "dostawczy":
            return KonfigurujDostawczy()
        elif item == "ciezarowka":
            return KonfigurujCiezarowke()
        else:
            return None


class KonfigurujDostawczy(Auto):

    def __init__(self):
        self.nazwa = 'Dostawczy'


class KonfigurujCiezarowke(Auto):

    def __init__(self):
        self.nazwa = 'Ciezarowka'


# Osobowe
class OsoboweAuta(SalonSamochodowy):

    def __init__(self):
        pass

    def konfigurujAuto(self, item):
        if item == "SUV":
            return KonfigurujSUV()
        elif item == "Sedan":
            return KonfigurujSedan()
        else:
            return None


class KonfigurujSUV(Auto):

    def __init__(self):
        self.nazwa = 'Osobowy - SUV'


class KonfigurujSedan(Auto):

    def __init__(self):
        self.nazwa = 'Osobowe - Sedan'


p = ZamowSamochod()
