from karoseria_abstract_class import Karoseria
from Metoda_wytworcza_karoserii_abstract_class import FabrykaKaroserii
from blotniki import Blotniki
from drzwi import Drzwi
from lakier import Lakier
from maska import Maska
from szyby import Szyby


class FabrykaKaroseriiMetodaWytworcza(FabrykaKaroserii):

    def karoseria_factory(self, nazwa: str) -> Karoseria:
        element = self.element_karoserii(nazwa)
        element.dodaj_element()
        element.testuj()
        return element

    def element_karoserii(self, typ: str) -> Karoseria:
        if typ == 'blotniki':
            karoseria = Blotniki({'typ': 'karbonowe'})
        elif typ == 'drzwi':
            karoseria = Drzwi({'typ': 'podnoszone'})
        elif typ == 'lakier':
            karoseria = Lakier({'kolor': 'czerwony'})
        elif typ == 'maska':
            karoseria = Maska()
        elif typ == 'szyby':
            karoseria = Szyby({'typ': 'elektryczne'})
        else:
            karoseria = None
        return karoseria


def main():
    fabryka = FabrykaKaroseriiMetodaWytworcza()
    wytworzony_element = fabryka.karoseria_factory('blotniki')
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_factory('drzwi')
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_factory('lakier')
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_factory('maska')
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_factory('szyby')
    print(wytworzony_element)
    print(wytworzony_element.get_elementy())


if __name__ == '__main__':
    main()
