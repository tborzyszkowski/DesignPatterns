from karoseria_abstract_class import Karoseria
from Metoda_wytworcza_karoserii_abstract_class import FabrykaKaroserii


class FabrykaKaroseriiMetodaWytworcza(FabrykaKaroserii):

    def karoseria_factory(self, nazwa: str, parametry: set = []) -> Karoseria:
        element = self.element_karoserii(nazwa, parametry)
        element.dodaj_element()
        element.testuj()
        return element

    def element_karoserii(self, typ: str, parametry: set = []) -> Karoseria:
        """ Implementacja rejestracji klas z uzyciem refleksji """

        # Funkcje nadpisujące metody abstrakcyjne w nadklasie
        def dodaj_element(self):
            pass

        def testuj(self):
            pass

        def usun_element(self):
            pass

        klasa = type(typ, (Karoseria,), {"dodaj_element": dodaj_element,
                                         "testuj": testuj,
                                         "usun_element": usun_element})
        if typ not in globals():
            globals()[typ] = klasa
        karoseria = klasa(parametry)
        return karoseria


def main():
    fabryka = FabrykaKaroseriiMetodaWytworcza()
    wytworzony_element = fabryka.karoseria_factory('Nadkola', {'typ': 'proste'})
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_factory('Drzwi-lewe')
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_factory('Drzwi-prawe')
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_factory('Dach', {'typ': 'skladany'})
    print(wytworzony_element)
    wytworzony_element = fabryka.karoseria_factory('Szyberdach', {'rodzaj': 'elektryczny'})
    print(wytworzony_element)
    print(wytworzony_element.get_elementy())


if __name__ == '__main__':
    main()
