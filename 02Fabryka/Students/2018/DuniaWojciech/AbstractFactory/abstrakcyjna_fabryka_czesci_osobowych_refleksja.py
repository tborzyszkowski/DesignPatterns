from typing import List

from abstrakcyjna_fabryka_czesci_abstract_class import AbstrakcyjnaFabrykaCzesci
from karoseria_abstract_class import Karoseria
from podwozie_abstract_class import Podwozie
from silnik_abstract_class import Silnik
from wyposazenie_abstract_class import Wyposazenie


class FabrykaCzesciOsobowych(AbstrakcyjnaFabrykaCzesci):
    def wytworz_karoserie(self) -> List[Karoseria]:
        return [self.tworz_klase('Blotniki', Karoseria), self.tworz_klase('Drzwi', Karoseria), self.tworz_klase('Maska', Karoseria)]

    def wytworz_podwozie(self) -> List[Podwozie]:
        return [self.tworz_klase('Kola', Podwozie), self.tworz_klase('Osie', Podwozie), self.tworz_klase('Opony', Podwozie)]

    def wytworz_silnik(self) -> List[Silnik]:
        return [self.tworz_klase('Blok', Silnik), self.tworz_klase('Tloki', Silnik), self.tworz_klase('Przewody', Silnik)]

    def wytworz_wyposazenie(self) -> List[Wyposazenie]:
        return [self.tworz_klase('Fotele', Wyposazenie), self.tworz_klase('CD', Wyposazenie), self.tworz_klase('GPS', Wyposazenie)]

    """ Implementacja rejestracji klas z uzyciem refleksji """
    def tworz_klase(self, typ: str, nadklasa: object, parametry: set = []):
        metody_nadklasy = self.get_metody_klasy(nadklasa)
        klasa = type(typ, (nadklasa,), metody_nadklasy)
        if typ not in globals():
            globals()[typ] = klasa
        karoseria = klasa(parametry)
        return karoseria

    """ Pobieranie metod abstrakcyjnych z nadklasy z uzyciem refleksji """
    def get_metody_klasy(self, klasa: object):
        metody = [method_name for method_name in dir(klasa) if method_name.find('_')]
        zestaw = {}
        for m in metody:
            zestaw.update({m: lambda self: ()})
        return zestaw
