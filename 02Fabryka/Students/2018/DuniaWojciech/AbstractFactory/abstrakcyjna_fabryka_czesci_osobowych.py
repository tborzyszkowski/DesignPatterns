from typing import List

from abstrakcyjna_fabryka_czesci_abstract_class import AbstrakcyjnaFabrykaCzesci
from karoseria_abstract_class import Karoseria
from podwozie_abstract_class import Podwozie
from silnik_abstract_class import Silnik
from wyposazenie_abstract_class import Wyposazenie

from blotniki import Blotniki
from drzwi import Drzwi
from lakier import Lakier
from maska import Maska
from szyby import Szyby
from kola import Kola
from opony import Opony
from osie import Osie
from plyta_podlogowa import Plyta_podlogowa
from zawieszenie import Zawieszenie
from akumulator import Akumulator
from blok_silnika import Blok_silnika
from chlodnica import Chlodnica
from rozrusznik import Rozrusznik
from tloki import Tloki
from fotele import Fotele
from kierownica import Kierownica
from nawigacja import Nawigacja
from radio import Radio
from tapicerka import Tapicerka


class FabrykaCzesciOsobowych(AbstrakcyjnaFabrykaCzesci):
    def wytworz_karoserie(self) -> List[Karoseria]:
        return [Blotniki(), Drzwi(), Maska(), Lakier()]

    def wytworz_podwozie(self) -> List[Podwozie]:
        return [Kola(), Osie(), Opony()]

    def wytworz_silnik(self) -> List[Silnik]:
        return [Blok_silnika(), Tloki(), Chlodnica()]

    def wytworz_wyposazenie(self) -> List[Wyposazenie]:
        return [Fotele(), Kierownica(), Nawigacja(), Radio()]
